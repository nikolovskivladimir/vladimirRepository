using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HealthCare.Data.Models
{
    public class PatientVisit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Patient Patient { get; set; }
        public Visit Visit { get; set; }
        public PatientVisitStatus Status { get; set; }
        public DateTime VisitDate { get; set; }
        public string Comment { get; set; }

    }
}
