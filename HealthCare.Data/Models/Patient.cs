using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HealthCare.Data.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<PatientVisit> PatientVisits { get; set; }

        public Patient(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email)
        {
            PatientVisits = new List<PatientVisit>();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void AddPatientVisit(PatientVisit patientVisit)
        {
            PatientVisits.Add(patientVisit);
        }
    }
}
