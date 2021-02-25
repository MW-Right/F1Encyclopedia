import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './Common/components/nav-menu/nav-menu.component';
import { HomeComponent } from './Home/containers/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { DriversModule } from './Drivers/drivers.module';
import { MatProgressSpinnerModule, MatTableModule } from '@angular/material';
import { DriversSnapshotComponent } from './Drivers/components/drivers-snapshot/drivers-snapshot.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
    ]),
    BrowserAnimationsModule,

    MatTableModule,
    MatProgressSpinnerModule,

    DriversModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
