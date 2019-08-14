using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCare.Business.Interfaces;
using HealthCare.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        public static IPatientSystem _patientSystem;
        public PatientController(IPatientSystem patientSystem)
        {
            _patientSystem = patientSystem;
        }

        public JsonResult GetAllPatientsForGrid()
        {
            return Json(new List<Patient>() {
                new Patient("Patient1","Patient11", DateTime.Today, "12419024","asfas@mail.com"),
                new Patient("Patient2","Patient22", DateTime.Today, "12419024","asfas@mail.com"),
                new Patient("Patient3","Patient33", DateTime.Today, "12419024","asfas@mail.com"),
                new Patient("Patient4","Patient44", DateTime.Today, "12419024","asfas@mail.com"),
                new Patient("Patient5","Patient55", DateTime.Today, "12419024","asfas@mail.com"),
                new Patient("Patient6","Patient66", DateTime.Today, "12419024","asfas@mail.com"),
                new Patient("Patient7","Patient77", DateTime.Today, "12419024","asfas@mail.com"),
            });
        }

    }
}