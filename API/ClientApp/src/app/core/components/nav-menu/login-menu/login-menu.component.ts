import { Component } from '@angular/core';
import { AuthorizeService } from '@core/services/auth/authorize.service';

@Component({
    selector: 'login-menu',
    templateUrl: './login-menu.component.html'
})
export class LoginMenuComponent {

    user$ = this.authorizeService.userState$;

    constructor(private authorizeService: AuthorizeService) {
    }

    logout(): void {
        this.authorizeService.logout();
    }

}
