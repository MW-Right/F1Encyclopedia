import { Component, Input, OnChanges, OnInit, SimpleChange, SimpleChanges } from "@angular/core";
import { DriverSnapshot } from "../../models";
import { DriversService } from "../../services";

@Component({
    selector: 'f1-drivers-snapshot',
    templateUrl: './drivers-snapshot.component.html',
    styleUrls: ['./drivers-snapshot.component.scss']
})
export class DriversSnapshotComponent implements OnInit, OnChanges {
    @Input() driverSnapshots: DriverSnapshot[];
    dataSource: DriverSnapshot[];

    displayedColumns: string[] = [
        "driverName",
        "points"
    ];
    
    constructor(private driverService: DriversService) { }

    ngOnInit() {
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes.driverSnapshots && this.driverSnapshots) {
            this.dataSource = this.driverSnapshots;
        }
    }
}