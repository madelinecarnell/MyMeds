using NUnit.Framework;
using MyMeds.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using MyMeds.Data;
using Microsoft.EntityFrameworkCore;
using Castle.Core.Internal;
using System.Threading.Tasks;
using MyMeds.Services;


namespace MyMedsTest
{
    public class MyMedsTest
    {
        private List<MedicationModel> medications;
      
        

        [SetUp]
        public void Setup()
        {
            medications = new List<MedicationModel>();
            medications.Add(new MedicationModel() { Id = 4, LogonsId = 1, MedicationName = "lipitor" });
            medications.Add(new MedicationModel() { Id = 5, LogonsId = 1, MedicationName = "atorvastatin" });
        }

        [Test]
        public void ShouldMapMedication()
        {
            var med = new MedicationModel();
            med.Id = 1;
            med.MedicationName = "lipitor";

            var med2 = new MedicationModel();
            med.Id = 2;
            Assert.AreNotEqual(med, med2);
        }

        [Test]
        public void ShouldCountListofMeds()
        {
            var amount = medications.Count();
            bool amountOfMeds = amount.Equals(2);
            Assert.IsTrue(amountOfMeds);
        }

        [Test]
        public void ShouldLogonUser()
        {
            var logon = new LogonModel();
            logon.UserId = "MaddieCarnell";
            logon.Password = "Maddie1";
            var controller = new UserServices();
            var homeLogon = controller.PasswordSignIn(logon.UserId, logon.Password);
            var result = homeLogon.ToString();
            result.Equals(true);
        }

        [Test]
        public void ShouldNotLogonUser()
        {
            var logon = new LogonModel();
            logon.UserId = "MaddieCarnell";
            logon.Password = "Maddie1";
            var controller = new UserServices();
            var homeLogon = controller.PasswordSignIn(logon.UserId, logon.Password);
            var result = homeLogon.ToString();
            result.Equals(false);
        }

        [Test]
        public void ShouldCreateDrug()
        {
            var logon = new LogonModel();
            logon.UserId = "MaddieCarnell";
            logon.Password = "Maddie1";
            var med = new MedicationModel();
            med.Id = 1;
            med.MedicationName = "lipitor";
            med.Refills = 3;
            med.LogonsId = 1;
            var controller = new UserServices();
            var result = controller.CreateMedicationTask(med, med.LogonsId);
            result.Equals(true);
        }

        [Test]
        public void ShouldNotCreateDrug()
        {
            var logon = new LogonModel();
            logon.UserId = "MaddieCarnell";
            logon.Password = "Maddie1";
            var med = new MedicationModel();
            med.Id = 1;
            med.Refills = 3;
            med.LogonsId = 1;
            var controller = new UserServices();
            var result = controller.CreateMedicationTask(med, med.LogonsId);
            result.Equals(false);
        }

        [Test]
        public void ShouldGrabMedByUser()
        {
            var logon = new LogonModel();
            logon.UserId = "MaddieCarnell";
            logon.Password = "Maddie1";
            var controller = new UserServices();
            var result = controller.GrabDataForUser(logon.UserId);
            var count = result.Medications.Count;
            count.Equals(3);
        }

        [Test]
        public void ShouldNotGrabMedForInvalidUser()
        {
            var logon = new LogonModel();
            logon.UserId = "baddata";
            logon.Password = "wrongpassword";
            var controller = new UserServices();
            var result = controller.GrabDataForUser(logon.UserId);
            var count = result.Medications.Count;
            count.Equals(0);
        }

        [Test]
        public void ShouldUpdateMedication()
        {
            var logon = new LogonModel();
            logon.UserId = "MaddieCarnell";
            logon.Password = "Maddie1";
            var med = new MedicationModel();
            med.Id = 1;
            med.MedicationName = "amlodipine";
            med.Refills = 3;
            med.LogonsId = 1;
            var controller = new UserServices();
            var result = controller.UpdateMedicationTask(med, med.LogonsId);
            result.Equals(true);
        }

        [Test]
        public void ShouldNotUpdateMedication()
        {
            var logon = new LogonModel();
            logon.UserId = "MaddieCarnell";
            logon.Password = "Maddie1";
            var med = new MedicationModel();
            med.Id = 1;
            med.Refills = 3;
            med.LogonsId = 1;
            var controller = new UserServices();
            var result = controller.UpdateMedicationTask(med, med.LogonsId);
            result.Equals(false);
        }

        [Test]
        public void ShouldDeleteMedication()
        {
            var logon = new LogonModel();
            logon.UserId = "MaddieCarnell";
            logon.Password = "Maddie1";
            var med = new MedicationModel();
            med.Id = 1;
            med.MedicationName = "amlodipine";
            med.Refills = 3;
            med.LogonsId = 1;
            var controller = new UserServices();
            var result = controller.DeleteMedicationTask(med, med.LogonsId);
            result.Equals(true);
        }

        [Test]
        public void ShouldNotDeleteMedicationNoId()
        {
            var logon = new LogonModel();
            logon.UserId = "MaddieCarnell";
            logon.Password = "Maddie1";
            var med = new MedicationModel();
            med.MedicationName = "amlodipine";
            med.Refills = 3;
            med.LogonsId = 1;
            var controller = new UserServices();
            var result = controller.DeleteMedicationTask(med, med.LogonsId);
            result.Equals(false);
        }

        [Test]
        public void ShouldNotDeleteMedicationNoMedName()
        {
            var logon = new LogonModel();
            logon.UserId = "MaddieCarnell";
            logon.Password = "Maddie1";
            var med = new MedicationModel();
            med.Refills = 3;
            med.LogonsId = 1;
            med.Id = 1;
            var controller = new UserServices();
            var result = controller.DeleteMedicationTask(med, med.LogonsId);
            result.Equals(false);
        }

        [Test]
        public void ShouldNotDeleteMedicationNoRefills()
        {
            var logon = new LogonModel();
            logon.UserId = "MaddieCarnell";
            logon.Password = "Maddie1";
            var med = new MedicationModel();
            med.LogonsId = 1;
            med.MedicationName = "amlodipine";
            med.Id = 1;
            var controller = new UserServices();
            var result = controller.DeleteMedicationTask(med, med.LogonsId);
            result.Equals(false);
        }

        [Test]
        public void GrabMedicationToList()
        {
            var logon = new LogonModel();
            logon.UserId = "MaddieCarnell";
            logon.Password = "Maddie1";
            var controller = new UserServices();
            var result = controller.GrabMedicationsOnlyToList(logon.UserId);
            var resultList = result.ToList();
            var resultCount = resultList.Count();
            var count = 2;
            Assert.AreEqual(resultCount, count);
        }

        [Test]
        public void ShouldNotGrabMedicationToList()
        {
            var logon = new LogonModel();
            logon.UserId = "fakeUser";
            logon.Password = "badData";
            var controller = new UserServices();
            var result = controller.GrabMedicationsOnlyToList(logon.UserId);
            var resultList = result.ToList();
            var resultCount = resultList.Count();
            var count = 0;
            Assert.AreEqual(resultCount, count);
        }
    }
}