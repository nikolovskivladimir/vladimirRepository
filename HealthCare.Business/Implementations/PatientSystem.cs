using HealthCare.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using HealthCare.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using HealthCare.Business.Interfaces;
using HealthCare.Repository;

namespace HealthCare.Business.Implementations
{
    public class PatientSystem: IPatientSystem
    {
        private static IUnitOfWork _unitOfWork;
        public PatientSystem(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<Patient> GetAllPatients()
        {
            var patients = _unitOfWork.PatientRepository.GetAll();
            return patients.ToList();
        }

        public void CreatePatient()
        {
            var patient = new Patient("Ime", "Prezime", DateTime.Today, "31231231", "email");

            _unitOfWork.PatientRepository.Insert(patient);
            _unitOfWork.SaveChanges();
        }
    }
}
