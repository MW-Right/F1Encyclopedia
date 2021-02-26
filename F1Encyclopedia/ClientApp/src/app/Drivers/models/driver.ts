import { Country, Deserialisable } from "src/app/Common/models";

export class Driver implements Deserialisable {
    id: number;
    firstName: number;
    lastName: number;
    dob: Date;
    wikiUrl: string;
    country: Country;
    number: number;
    daddysCash: boolean;
    pace: number;
    experience: number;
    racecraft: number;
    awareness: number;

    deserialise(input: any): this {
        return Object.assign(this, input);
    }

    getFullName(): string {
        return `${this.firstName} ${this.lastName}`;
    }
}