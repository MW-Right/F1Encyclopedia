import { Component, HostListener, Input, OnChanges, SimpleChanges } from "@angular/core";
import { Driver, DriverSnapshot } from "../../models";
import { DriversService } from "../../services";

@Component({
    selector: 'f1-drivers-snapshot',
    templateUrl: './drivers-snapshot.component.html',
    styleUrls: ['./drivers-snapshot.component.scss']
})
export class DriversSnapshotComponent implements OnChanges {
    @Input() driverSnapshots: DriverSnapshot[];

    firstColumnSnapshots: DriverSnapshot[];
    secondColumnSnapshots: DriverSnapshot[];

    driverSnapshotsLength: number;
    isCondensedView = false;
 
    constructor(private driverService: DriversService) { }

    ngOnChanges(changes: SimpleChanges) {
        if (changes.driverSnapshots && this.driverSnapshots) {
            this.firstColumnSnapshots = this.driverSnapshots.slice(0, 5);
            this.secondColumnSnapshots = this.driverSnapshots.slice(5, 10);
            this.driverSnapshotsLength = this.driverSnapshots.length;

            if (this.driverSnapshotsLength <= 5 || window.innerWidth < 768) {
                this.isCondensedView = true;
            }
            else {
                this.isCondensedView = false;
            }
        }
    }

    @HostListener("window:resize", ['$event'])
    onResize(event?) {
        if (window.innerWidth < 768) {
            this.isCondensedView = true;
        }
        else {
            this.isCondensedView = this.driverSnapshotsLength <= 5;
        }
    }
}