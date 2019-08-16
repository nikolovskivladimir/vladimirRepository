import { Component, Inject } from '@angular/core';
import { IPatient, Patient } from './IPatient';
import { PatientService } from './patients.services';
//import { NgbModal, ModalDismissReasons } from 'bootstrap';
//import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

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

  editPatient(id:number) {
    debugger;
  }

  updatePatient(id: number) {
    debugger;
  }

  createPatient() {
    //this.modalService.open("asdasd", { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
    // // this.closeResult = `Closed with: ${result}`;
    //}, (reason) => {
    //  //this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    //});
  }
}

