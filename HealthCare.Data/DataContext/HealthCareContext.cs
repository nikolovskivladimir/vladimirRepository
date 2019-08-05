using HealthCare.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Data.DataContext
{
    public class HealthCareContext : DbContext
    {
        public HealthCareContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientVisit> PatientVisits { get; set; }
        public DbSet<PatientVisitStatus> PatientVisitStatuses { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}
