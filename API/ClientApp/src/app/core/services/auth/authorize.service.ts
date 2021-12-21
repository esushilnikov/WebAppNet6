import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, concat, map, Observable, share } from 'rxjs';
import { take, tap } from 'rxjs/operators';
import { AuthModel } from 'src/app/core/models/auth.model';
import { SignInModel } from '../../models/sign-in.model';
import { UserModel } from '../../models/user.model';
import { LocalStorageService } from '../local-storage.service';

@Injectable({
    providedIn: 'root'
})
export class AuthorizeService {

    private readonly userState = new BehaviorSubject<UserModel | null>(null);

    user$ = concat(this.userState.asObservable().pipe(take(1)), this.fetch$()).pipe(share());

    constructor(private http: HttpClient,
                private localStorageService: LocalStorageService) {
    }

    isAuthenticated(): Observable<boolean> {
        return this.userState.asObservable().pipe(map(u => !!u));
    }

    authenticate(model: SignInModel): Observable<AuthModel> {
        return this.http.post<AuthModel>('api/account/authenticate', model).pipe(
            tap(x => this.localStorageService.setItem('access_token', x.token)));
    }

    register(model: SignInModel): Observable<any> {
      return this.http.post<any>('api/account/register', model);
    }

    logout$(): Observable<boolean> {
        this.userState.next(null);
        return this.http.post<boolean>('api/account/sign-out', {});
    }

    getUser(): Observable<UserModel | null> {
        return concat(this.userState.asObservable().pipe(take(1)), this.fetch$()).pipe(share());
    }

    private fetch$(): Observable<UserModel> {
        return this.http.get<UserModel>('api/user').pipe(
            tap(user => this.userState.next(user)));
    }
}
