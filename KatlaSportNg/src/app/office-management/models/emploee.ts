import { Binary } from "@angular/compiler";

export class Employee {
    constructor(
        public id: number,
        public name: string,
        public address: string,
        public phone: string,
        public officeId:number,
        public avatar: string
    ) { }
}