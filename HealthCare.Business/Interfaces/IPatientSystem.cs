using HealthCare.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Business.Interfaces
{
    public interface IPatientSystem
    {
        List<Visit> GetAllPatients();
        void AddPatients();
    }
}
