import { Component, Input, OnChanges, SimpleChanges } from "@angular/core";
import { DriverSnapshot } from "../../models";

@Component({
    selector: 'f1-driver-snapshot-table',
    templateUrl: './driver-snapshot-table.component.html',
    styleUrls: ['./driver-snapshot-table.component.scss']
})
export class DriverSnapshotTableComponent implements OnChanges {
    @Input() snapshots: DriverSnapshot[];
    
    displayedColumns: string[] = [
        "driverName",
        "points"
    ];

    ngOnChanges(changes: SimpleChanges) {
        if (changes.snapshots) {
        }
    }
}