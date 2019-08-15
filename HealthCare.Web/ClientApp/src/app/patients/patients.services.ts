import { Injectable, Inject } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { IPatient } from "./IPatient";

@Injectable()
export class PatientService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'my-auth-token'
    })
  };
  baseUrl = "";
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getPatients() {
    return this.http.get<IPatient[]>(this.baseUrl + "api/Patient/GetPatients");
  }


}
