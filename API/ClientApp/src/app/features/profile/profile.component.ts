import { Component } from '@angular/core';
import { AuthorizeService } from '@core/services/auth/authorize.service';

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html'
})
export class ProfileComponent {

    user$ = this.authorizeService.userState$;

    constructor(private authorizeService: AuthorizeService) {
    }

}
