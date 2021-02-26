import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { MatCardModule, MatProgressSpinnerModule, MatTableModule } from "@angular/material";
import { RouterModule } from "@angular/router";
import { DriverSnapshotTableComponent } from "./components/driver-snapshot-table.component.ts/driver-snapshot-table.component";
import { DriversSnapshotComponent } from "./components/drivers-snapshot/drivers-snapshot.component";
import { DriversService } from "./services";

@NgModule({
    declarations: [
        DriversSnapshotComponent,
        DriverSnapshotTableComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        
        RouterModule.forRoot([
            { path: 'drivers', component: DriversSnapshotComponent, pathMatch: 'full' },
          ]),

        MatCardModule,
        MatTableModule,
        MatProgressSpinnerModule,
    ],
    exports: [
        DriversSnapshotComponent,
        DriverSnapshotTableComponent
    ],
    providers: [DriversService],
    bootstrap: []
})
export class DriversModule { }