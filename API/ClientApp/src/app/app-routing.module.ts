import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from '@core/components/home/home.component';
import { LoginComponent } from '@core/components/login/login.component';
import { RegisterComponent } from '@core/components/register/register.component';

const routes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'register',
        component: RegisterComponent
    },
    { path: 'profile', loadChildren: () => import('./features/profile/profile.module').then(m => m.ProfileModule) },
    {
        path: '**',
        redirectTo: ''
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
