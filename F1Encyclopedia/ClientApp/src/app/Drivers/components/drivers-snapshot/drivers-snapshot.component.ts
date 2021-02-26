import { Component, Input, OnChanges, SimpleChanges } from "@angular/core";
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
            this.driverSnapshotsLength = this.driverSnapshots.length;
            if (this.driverSnapshotsLength <= 5) {
                this.isCondensedView = true;
            }
            else {
                this.isCondensedView = false;
                this.firstColumnSnapshots = this.driverSnapshots.slice(0, Math.round(this.driverSnapshotsLength / 2))
                this.secondColumnSnapshots = this.driverSnapshots.slice(Math.round(this.driverSnapshotsLength / 2) - 1, this.driverSnapshotsLength - 1);
            }
        }
    }
}