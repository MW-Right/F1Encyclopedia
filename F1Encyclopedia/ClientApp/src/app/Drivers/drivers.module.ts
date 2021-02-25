import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { MatProgressSpinnerModule, MatTableModule } from "@angular/material";
import { RouterModule } from "@angular/router";
import { DriversSnapshotComponent } from "./components/drivers-snapshot/drivers-snapshot.component";
import { DriversService } from "./services";

@NgModule({
    declarations: [
        DriversSnapshotComponent
    ],
    imports: [
        FormsModule,
        
        RouterModule.forRoot([
            { path: 'drivers', component: DriversSnapshotComponent, pathMatch: 'full' },
          ]),

        MatTableModule,
        MatProgressSpinnerModule,
    ],
    exports: [
        DriversSnapshotComponent
    ],
    providers: [DriversService],
    bootstrap: []
})
export class DriversModule { }