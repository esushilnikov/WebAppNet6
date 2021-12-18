import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthorizeService } from '../../services/auth/authorize.service';
import { LoginForm } from './login.model';

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
            [this.controlName.userName]: this.fb.control('', Validators.required),
            [this.controlName.password]: this.fb.control('', Validators.required),
        });
    }

    submit(): void {
        this.authorizeService.login$(this.form.value).subscribe(() => this.router.navigate(['/']));
    }

}