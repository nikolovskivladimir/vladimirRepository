//import { UserRoleEnum } from "../../enums/UserRoleEnum";

export interface IPatient {
  Id: number;
  FirstName: string;
  LastName: string;
  //Active: boolean;
  DateOfBirth: Date;
  PhoneNumber: string;
  Email: string;
  //PatientVisits: [];
}


export class Patient implements IPatient {
  Id: number;
  FirstName: string;
  LastName: string;
  //Active: boolean;
  DateOfBirth: Date;
  PhoneNumber: string;
  Email: string;
  //PatientVisits: [];

  constructor() {

    this.Id = 0;
    this.FirstName = "";
    this.LastName = "";
    //this.Active = false;
    this.DateOfBirth = null;
    this.PhoneNumber = "";
    this.Email = "";
    //this.PatientVisits = [];
  }
}
