import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { AuthorizeService } from "@core/services/auth/authorize.service";
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AuthorizeGuard implements CanActivate {
    constructor(private authorize: AuthorizeService, private router: Router) {
    }

    canActivate(
        _next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        const isAuthenticated = this.authorize.isAuthenticated;

        if (!isAuthenticated) {
            this.router.navigate(['login']);
        }

        return isAuthenticated;
    }
}
