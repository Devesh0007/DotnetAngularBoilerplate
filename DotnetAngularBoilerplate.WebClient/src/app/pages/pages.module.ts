import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { DashboardComponent } from './admin/dashboard.component';
import { CoreModule } from "../@core/core.module";


@NgModule({
    declarations: [
        DashboardComponent
    ],
    imports: [
        CommonModule,
        PagesRoutingModule,
        CoreModule
    ]
})
export class PagesModule { }
