import { Component } from "@angular/core";

@Component({
  selector: "f1-loading",
  templateUrl: "./loading.component.html",
  styles: [
    `
      .f1-loading-container {
        color: white;
        display: block;
        width: 200px;
        margin: 200px auto 0 auto;
        padding: 0;
      }
      .f1-progress-spinner {
          left: 80px;
      }
      p {
          text-align: center;
          width: 200px;
      }
    `,
  ],
})
export class F1LoadingComponent {}
