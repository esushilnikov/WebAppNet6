import { Component } from '@angular/core';
import { AuthorizeService } from '@core/services/auth/authorize.service';
import { LocalStorageService } from '@core/services/local-storage.service';

@Component({
    selector: 'login-menu',
    templateUrl: './login-menu.component.html'
})
export class LoginMenuComponent {

    user$ = this.authorizeService.userState$;

    constructor(private authorizeService: AuthorizeService,
                private localStorageService: LocalStorageService) {
    }

    logout(): void {
        this.localStorageService.removeItem('access_token');
        this.authorizeService.logout();
    }

}
