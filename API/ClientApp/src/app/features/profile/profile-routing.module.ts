import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from '@core/services/auth/authorize-guard';
import { ProfileComponent } from '@features/profile/profile.component';

const routes: Routes = [{
    path: '',
    component: ProfileComponent,
    canActivate: [AuthorizeGuard]
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProfileRoutingModule {
}
