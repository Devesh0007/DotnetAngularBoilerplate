import { Component } from '@angular/core';
import { SharedService } from 'src/app/@shared/services/shared.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
constructor(public sharedService: SharedService){

}
}
