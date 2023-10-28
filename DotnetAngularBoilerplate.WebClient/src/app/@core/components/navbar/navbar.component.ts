import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  
  ngOnInit(): void {
    //this.initializeNavbar();
    console.log("Navbar")
  }
  showNavbar(toggleId: string, navId: string, bodyId: string, headerId: string){
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

  
}
