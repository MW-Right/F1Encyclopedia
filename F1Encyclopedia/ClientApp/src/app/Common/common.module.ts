import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { MaterialModule } from "../material.module";

import { F1LoadingComponent, NavMenuComponent } from './components';

import { CountriesService } from './services/countries.service';

@NgModule({
    declarations: [
        F1LoadingComponent,
        NavMenuComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        MaterialModule
    ],
    exports: [
        NavMenuComponent,
        F1LoadingComponent
    ],
    providers: [CountriesService]
})
export class F1CommonModule { }