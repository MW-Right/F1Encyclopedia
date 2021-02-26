import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { DriverSnapshot } from 'src/app/Drivers/models';
import { DriversService } from 'src/app/Drivers/services';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  driverSnapshots$: Observable<DriverSnapshot[]>;
  
  constructor(private driversService: DriversService) {

  }

  ngOnInit() {
    this.driverSnapshots$ = this.driversService.getDriverSnapshots();
  }
}
