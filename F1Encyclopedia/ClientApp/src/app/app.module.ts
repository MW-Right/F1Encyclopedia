import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { AppComponent } from './app.component';
import { HomeComponent } from './Home/containers/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { F1CommonModule } from './Common/common.module';
import { DriversModule } from './Drivers/drivers.module';
import { MaterialModule } from './material.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    CommonModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
    ]),
    BrowserAnimationsModule,

    MaterialModule,
    F1CommonModule,
    DriversModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
