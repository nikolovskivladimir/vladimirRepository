using HealthCare.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Repository
{
    public interface IUnitOfWork
    {
        void SaveChanges();

        IRepository<Patient> PatientRepository { get; }
        IRepository<PatientVisit> PatientVisitRepository { get; }
        IRepository<Visit> VisitRepository { get; }
        IRepository<PatientVisitStatus> PatientVisitStatusRepository { get; }
    }
}
