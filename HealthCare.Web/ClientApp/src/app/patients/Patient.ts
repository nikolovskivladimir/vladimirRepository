import { IPatient } from "./IPatient";

export class Patient implements IPatient {
  Id: number;
  FirstName: string;
  LastName: string;
  //Active: boolean;
  DateOfBirth: Date;
  PhoneNumber: string;
  //PatientVisits: [];

  constructor() {

    this.Id = 0;
    this.FirstName = "";
    this.LastName = "";
    //this.Active = false;
    this.DateOfBirth = null;
    this.PhoneNumber = "";
    //this.PatientVisits = [];
  }
}
