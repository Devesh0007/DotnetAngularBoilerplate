import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/@shared/services/shared.service';
import { SessionStorageEnum } from '../../enums/session-storage';

@Component({
  selector: 'app-dashboard',
  templateUrl: './static.component.html',
  styleUrls: ['./static.component.scss']
})
export class StaticComponent implements OnInit {
  constructor(public sharedService: SharedService) {
  }
  ngOnInit() {
    this.sharedService.headerUserName = (sessionStorage.getItem(SessionStorageEnum.FirstName)?.charAt(0) ?? '') + (sessionStorage.getItem(SessionStorageEnum.LastName)?.charAt(0) ?? '');
  }
}
