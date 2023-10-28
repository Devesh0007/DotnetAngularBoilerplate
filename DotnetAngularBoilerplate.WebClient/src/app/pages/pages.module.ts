import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagesRoutingModule } from './pages-routing.module';
import { CoreModule } from "../@core/core.module";
import { DashboardComponent, UserManagementComponent } from '@pages';

@NgModule({
    declarations: [
        UserManagementComponent,
        DashboardComponent
    ],
    imports: [
        CommonModule,
        PagesRoutingModule,
        CoreModule
    ]
})
export class PagesModule { }
