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


        public List<Visit> GetAllPatients()
        {
            var patients = _unitOfWork.VisitRepository.GetAll();
            return patients.ToList();
        }

        public void AddPatients()
        {
            var visit1 = new Visit();
            visit1.Name = "Visit 1";

            var visit2 = new Visit();
            visit2.Name = "Visit 2";

            var visit3 = new Visit();
            visit3.Name = "Visit 3";

            _unitOfWork.VisitRepository.Insert(visit1);
            _unitOfWork.VisitRepository.Insert(visit2);
            _unitOfWork.VisitRepository.Insert(visit3);
            _unitOfWork.SaveChanges();
        }
    }
}
