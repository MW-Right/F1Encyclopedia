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
import { MatIconModule } from '@angular/material';

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
    MatIconModule,
  
    DriversModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
