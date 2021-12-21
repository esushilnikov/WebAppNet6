import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HomeComponent } from '@core/components/home/home.component';
import { LoginComponent } from '@core/components/login/login.component';
import { LoginMenuComponent } from '@core/components/nav-menu/login-menu/login-menu.component';
import { NavMenuComponent } from '@core/components/nav-menu/nav-menu.component';
import { RegisterComponent } from '@core/components/register/register.component';

@NgModule({
    declarations: [
        HomeComponent,
        NavMenuComponent,
        LoginComponent,
        LoginMenuComponent,
        RegisterComponent
    ],
    exports: [
        NavMenuComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        ReactiveFormsModule
    ]
})
export class CoreModule {
}
