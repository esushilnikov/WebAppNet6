import { Component } from '@angular/core';

@Component({
    selector: 'nav-menu',
    templateUrl: './nav-menu.component.html'
})
export class NavMenuComponent {

    isExpanded = false;

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }
}
