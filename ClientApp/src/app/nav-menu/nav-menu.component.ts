/**
 * Angular Component for Navigation Menu.
 */
import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  /**
   * Collapse the navigation menu.
   */
  collapse() {
    this.isExpanded = false;
  }

  /**
   * Toggle the navigation menu between expanded and collapsed states.
   */
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
