import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagesRoutingModule } from './pages-routing.module';
import { DashboardComponent, UserManagementComponent } from '@pages';
import { CoreModule, StaticComponent } from '../@core';

@NgModule({
    declarations: [
        StaticComponent,
        UserManagementComponent,
        DashboardComponent
    ],
    imports: [
        CommonModule,
        PagesRoutingModule,
        CoreModule
    ],
    bootstrap: [StaticComponent]
})
export class PagesModule { }
