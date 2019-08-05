using HealthCare.Data.DataContext;
using HealthCare.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private HealthCareContext _context { get; }

        public UnitOfWork(HealthCareContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IRepository<Patient> PatientRepository => new Repository<Patient>(_context);
        public IRepository<PatientVisit> PatientVisitRepository => new Repository<PatientVisit>(_context);
        public IRepository<Visit> VisitRepository => new Repository<Visit>(_context);
        public IRepository<PatientVisitStatus> PatientVisitStatusRepository => new Repository<PatientVisitStatus>(_context);
    }
}
