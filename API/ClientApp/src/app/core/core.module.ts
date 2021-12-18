import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { LoginComponent } from './components/login/login.component';
import { LoginMenuComponent } from './components/nav-menu/login-menu/login-menu.component';

@NgModule({
    declarations: [
        HomeComponent,
        NavMenuComponent,
        LoginComponent,
        LoginMenuComponent
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
