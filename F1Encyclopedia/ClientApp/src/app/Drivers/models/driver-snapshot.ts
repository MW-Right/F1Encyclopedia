import { Deserialisable } from "src/app/Common/models";
import { Driver } from "./driver";

export class DriverSnapshot implements Deserialisable {
    driver: Driver;
    points: number;

    deserialise(input: any): this {
        Object.assign(this, input);

        this.driver = new Driver().deserialise(input.driver);       
        
        return this;
    }
}