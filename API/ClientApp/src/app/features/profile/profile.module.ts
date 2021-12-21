import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ProfileRoutingModule } from '@features/profile/profile-routing.module';
import { ProfileComponent } from '@features/profile/profile.component';

@NgModule({
    declarations: [
        ProfileComponent
    ],
    imports: [
        CommonModule,
        ProfileRoutingModule
    ]
})
export class ProfileModule {
}
