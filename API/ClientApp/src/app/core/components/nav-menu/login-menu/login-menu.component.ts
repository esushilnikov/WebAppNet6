import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs';
import { AuthorizeService } from '../../../services/auth/authorize.service';
import { LocalStorageService } from '../../../services/local-storage.service';

@Component({
    selector: 'login-menu',
    templateUrl: './login-menu.component.html'
})
export class LoginMenuComponent implements OnInit {

    isAuthenticated = this.authorizeService.isAuthenticated();
    userName$ = this.authorizeService.user$.pipe(map(x => x?.userName));

    constructor(private authorizeService: AuthorizeService,
                private localStorageService: LocalStorageService) {
    }

    ngOnInit(): void {
    }

    logout(): void {
        this.localStorageService.removeItem('access_token');
        this.authorizeService.logout$();
    }

}
