import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthModel } from '@core/models/auth.model';
import { RegisterModel } from '@core/models/register.model';
import { SignInModel } from '@core/models/sign-in.model';
import { UserModel } from '@core/models/user.model';
import { LocalStorageService } from '@core/services/local-storage.service';
import { BehaviorSubject, concatMap, Observable, of, switchMap } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class AuthorizeService {

    private readonly StorageAuthKey = 'auth';
    private readonly userState = new BehaviorSubject<UserModel | null>(null);

    userState$ = this.userState.asObservable().pipe(
        switchMap(user => {
            if (this.isAuthenticated) {
                return user ? of(user) : this.getApiUser();
            }
            return of(null);
        }));

    constructor(private http: HttpClient,
                private router: Router,
                private localStorageService: LocalStorageService) {
    }

    get isAuthenticated(): boolean {
        return !!this.localStorageService.getItem(this.StorageAuthKey);
    }

    authenticate(model: SignInModel): Observable<any> {
        return this.http.post<AuthModel>('api/account/authenticate', model).pipe(
            tap(x => this.localStorageService.setItem(this.StorageAuthKey, JSON.stringify(x))),
            concatMap(() => this.getApiUser()),
            tap(() => this.router.navigate(['/'])));
    }

    register(model: RegisterModel): Observable<any> {
        return this.http.post<any>('api/account/register', model).pipe(
            tap(() => this.router.navigate(['login'])));
    }

    logout(): void {
        this.localStorageService.removeItem(this.StorageAuthKey);
        this.userState.next(null);
        this.router.navigate(['login']);
    }

    private getApiUser(): Observable<UserModel> {
        return this.http.get<UserModel>('api/user').pipe(tap(x => this.userState.next(x)));
    }
}
