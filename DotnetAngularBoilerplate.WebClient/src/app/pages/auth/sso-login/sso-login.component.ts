import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-sso-login',
  templateUrl: './sso-login.component.html',
  styleUrls: ['./sso-login.component.scss']
})
export class SsoLoginComponent implements OnInit {
  
  constructor(private router: Router, private route: ActivatedRoute, private authService: AuthService){

  }
  ngOnInit(): void {
    const queryParams = this.route.snapshot.queryParams;
    console.log(queryParams);
    this.authService.getLoginDetails(queryParams["token"]).subscribe(result=> {
      console.log("abc");
      
    });
  }

}
