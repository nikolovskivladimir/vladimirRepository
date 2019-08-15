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

        [HttpGet("[action]")]
        public JsonResult GetPatients()
        {
            try
            {
                var patients = _patientSystem.GetAllPatients();
                return Json(patients);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }

        }

    }
}