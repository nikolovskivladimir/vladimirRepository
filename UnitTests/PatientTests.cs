using HealthCare.Business.Implementations;
using HealthCare.Business.Interfaces;
using HealthCare.Data.Models;
using HealthCare.Repository;
using System;
using Xunit;

namespace UnitTests
{
    public class PatientTests
    {
        [Fact]
        public void CreatePatient_Test()
        {
            var patient = new Patient("Ime", "Prezime", DateTime.Today, "31231231", "email");

            var userRepositoryMock = new Mock<IRepository<Patient>>();
            userRepositoryMock.Setup(m => m.Insert(user)).Verifiable();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.UserRepository).Returns(userRepositoryMock.Object);

            IPatientSystem sut = new PatientSystem(unitOfWorkMock.Object);
            //Act
            sut.CreateUser(patient);

            //Assert
            userRepositoryMock.Verify(r => r.Insert(patient), Times.Once);
            unitOfWorkMock.Verify(u => u.SaveChanges(), Times.Once);
        }
    }
}
