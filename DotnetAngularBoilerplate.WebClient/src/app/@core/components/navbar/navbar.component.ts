import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from 'src/app/@shared/services/shared.service';
import { IMenuItems } from '../../interfaces/menu-items.interface';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  menuList: IMenuItems[] = [] as IMenuItems[];
  activatedRoute = 0;
  constructor(public sharedService: SharedService, private router: Router, private route: ActivatedRoute) {

  }
  ngOnInit(): void {
    this.menuList = [
      {
        displayName: 'Dashboard',
        route: 'dashboard',
        icon: 'bx bx-grid-alt nav_icon'
      },
      {
        displayName: 'Users',
        route: 'user-management',
        icon: 'bx bx-user nav_icon'
      }
    ]

  }
  showNavbar(toggleId: string, navId: string, bodyId: string, headerId: string) {
    const toggle = document.getElementById(toggleId),
      nav = document.getElementById(navId),
      bodypd = document.getElementById(bodyId),
      headerpd = document.getElementById(headerId)

    // Validate that all variables exist
    if (toggle && nav && bodypd && headerpd) {
      // show navbar
      nav.classList.toggle('show')
      // change icon
      toggle.classList.toggle('bx-x')
      // add padding to body
      bodypd.classList.toggle('body-pd')
      // add padding to header
      headerpd.classList.toggle('body-pd')
    }
  }

  colorLink(this: any) {
    const linkColor = document.querySelectorAll('.nav_link')
    if (linkColor) {
      linkColor.forEach(l => l.classList.remove('active'))
      this.classList.add('active')
    }
  }

  navigateTo(route: string, index: number) {
    this.router.navigate([route]);
    this.activatedRoute = index;
    //document.getElementById('route')?.classList?.add('active')
  }
  onLogout() {
    sessionStorage.clear();
    this.router.navigate(['/auth/login']);
  }

  isActive(instruction: string): boolean {
    const a = this.route.snapshot.component?.toString();
    // return this.router.isRouteActive(this.router.generate(instruction));
    return a == instruction;
  }
}
