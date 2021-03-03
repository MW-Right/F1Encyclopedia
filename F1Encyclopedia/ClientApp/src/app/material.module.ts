import { NgModule } from "@angular/core";
import { MatButtonModule, MatCardModule, MatIconModule, MatMenuModule, MatProgressSpinnerModule } from "@angular/material";

@NgModule({
    imports: [
        MatButtonModule,
        MatMenuModule,
        MatProgressSpinnerModule,
        MatIconModule,
        MatCardModule
    ],
    exports: [
        MatButtonModule,
        MatMenuModule,
        MatProgressSpinnerModule,
        MatIconModule,
        MatCardModule
    ]
})
export class MaterialModule {}