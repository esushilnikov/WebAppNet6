import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthModel } from '@core/models/auth.model';
import { LocalStorageService } from '@core/services/local-storage.service';
import { catchError, EMPTY, Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AuthorizeInterceptor implements HttpInterceptor {
    constructor(private localStorageService: LocalStorageService,
                private router: Router) {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return this.processRequestWithToken(this.getToken(), req, next);
    }

    private processRequestWithToken(token: string | null, req: HttpRequest<any>, next: HttpHandler) {
        if (!!token) {
            req = req.clone({
                setHeaders: {
                    Authorization: `Bearer ${token}`
                }
            });
        }

        return next.handle(req).pipe(
            catchError(err => {
                if (err instanceof HttpErrorResponse) {
                    if (err.status === 401) {
                        this.router.navigate(['login']);
                    }
                }
                return EMPTY;
            })
        );
    }

    private getToken(): string {
        const auth = this.localStorageService.getItem('auth');
        if (auth) {
            const authData = JSON.parse(auth) as AuthModel;
            return authData.token;
        }
        this.router.navigate(['login']);
        return '';
    }
}
