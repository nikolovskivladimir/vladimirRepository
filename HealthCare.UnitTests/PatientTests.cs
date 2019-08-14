using HealthCare.Business.Implementations;
using HealthCare.Business.Interfaces;
using HealthCare.Data.Models;
using HealthCare.Repository;
using Moq;
using System;
using Xunit;

namespace HealthCare.UnitTests
{
    public class PatientTests
    {
        [Fact]
        public void CreatePatient_Test()
        {
            var patient = new Patient("Ime", "Prezime", DateTime.Today, "31231231", "email");

            var patientRepositoryMock = new Mock<IRepository<Patient>>();
            patientRepositoryMock.Setup(m => m.Insert(patient)).Verifiable();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.PatientRepository).Returns(patientRepositoryMock.Object);

            IPatientSystem patientSystem = new PatientSystem(unitOfWorkMock.Object);
            //Act
            patientSystem.CreatePatient();

            //Assert 
            unitOfWorkMock.Verify(r => r.PatientRepository.Insert(patient), Times.Once);
            unitOfWorkMock.Verify(u => u.SaveChanges(), Times.Once);
        }
    }
}
