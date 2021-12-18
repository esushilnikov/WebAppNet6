import { Component } from '@angular/core';
import { AuthorizeService } from '../../services/auth/authorize.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
})
export class HomeComponent {

    user$ = this.authorizeService.user$;

    constructor(private authorizeService: AuthorizeService) {
    }

}
