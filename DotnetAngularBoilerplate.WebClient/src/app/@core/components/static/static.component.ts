import { Component, OnDestroy, OnInit } from '@angular/core';
import { SharedService } from 'src/app/@shared/services/shared.service';
import { SessionStorageEnum } from '../../enums/session-storage';
import { Subject, fromEvent, takeUntil } from 'rxjs';

@Component({
  selector: 'app-dashboard',
  templateUrl: './static.component.html',
  styleUrls: ['./static.component.scss']
})
export class StaticComponent implements OnInit, OnDestroy {
  constructor(public sharedService: SharedService) {
  }

  private unsubscriber: Subject<void> = new Subject<void>();
  ngOnInit(): void {
    this.sharedService.headerUserName = (sessionStorage.getItem(SessionStorageEnum.FirstName)?.charAt(0) ?? '') + (sessionStorage.getItem(SessionStorageEnum.LastName)?.charAt(0) ?? '');

    history.pushState(null, '');

    fromEvent(window, 'popstate')
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((_) => {
        history.pushState(null, '');
      });
  }
  ngOnDestroy(): void {
    this.unsubscriber.next();
    this.unsubscriber.complete();
  }
}
