import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";
import { DriverSnapshot } from "../models";

@Injectable({
    providedIn: 'root'
})
export class DriversService {
    constructor(private http: HttpClient) { }

    getDriverSnapshots(constructorId: number = null): Observable<DriverSnapshot[]> {
        if (constructorId != null){
            const params = new HttpParams()
                .set('constructorId', constructorId.toString())
            return this.http.get<DriverSnapshot[]>(
                `/api/drivers/snapshot`, 
                {responseType: 'json', observe: 'body', params: params}
            ).pipe(tap(x => console.log(x)));
        }
        else {
            return this.http.get<DriverSnapshot[]>(
                `/api/drivers/snapshot`, 
                {responseType: 'json', observe: 'body'}
            )
        }
    }
}