import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthorizeService } from '@core/services/auth/authorize.service';
import { LoginForm } from '@core/components/login/login.model';

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

    form: FormGroup;
    controlName = LoginForm;

    constructor(private fb: FormBuilder,
                private route: ActivatedRoute,
                private router: Router,
                private authorizeService: AuthorizeService) {
    }

    ngOnInit(): void {
        this.form = this.fb.group({
            [this.controlName.email]: this.fb.control('jeff.smith@mail.ua', Validators.required),
            [this.controlName.password]: this.fb.control('Qwerty!23456', Validators.required),
        });
    }

    login(): void {
        this.authorizeService.authenticate(this.form.value).subscribe();
    }

    register(): void {
        this.router.navigate(['register']);
    }

}
