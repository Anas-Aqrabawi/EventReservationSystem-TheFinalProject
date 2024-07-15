import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-nav-bar-webiste',
  templateUrl: './nav-bar-webiste.component.html',
  styleUrl: './nav-bar-webiste.component.css',
})
export class NavBarWebisteComponent implements OnInit {
  items: MenuItem[] | undefined;
  constructor(private router: Router) {}

  ngOnInit(): void {
    this.items = [
      {
        label: 'Home',
        icon: 'pi pi-home',
        command: () => this.NavigateTo(''),
      },

      {
        label: 'Login',
        icon: 'pi pi-lock',
        command: () => this.NavigateTo('Authentication/Login'),
      },

      {
        label: 'About us',
        icon: 'pi pi-search',
        command: () => this.NavigateTo('About'),
      },
      {
        label: 'Contact',
        icon: 'pi pi-phone',
        command: () => this.NavigateTo('Contact'),
      },
    ];
  }

  NavigateTo(dest: string) {
    this.router.navigate([dest]);
  }
}
