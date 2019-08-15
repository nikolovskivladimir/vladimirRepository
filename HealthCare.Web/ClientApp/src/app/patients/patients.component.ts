import { Component, Inject } from '@angular/core';
import { IPatient } from './IPatient';
import { PatientService } from './patients.services';

@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html'
})
export class PatientsComponent {
  public patients: IPatient[];

  constructor(private patientService: PatientService, @Inject('BASE_URL') baseUrl: string) {
    this.getPatients();
  }

  getPatients() {
    this.patientService.getPatients()
      .subscribe((patients: IPatient[]) => {
        this.patients = patients;
    });
  }
}

