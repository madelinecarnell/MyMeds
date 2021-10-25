using NUnit.Framework;
using MyMeds.Controllers;
using MyMeds;
using MyMeds.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyMeds.Data;

namespace MyMedsTest
{
    public class MyMedsTest
    {
        private List<Medication> medications;
        private readonly ILogger<HomeController> _logger;


        [SetUp]
        public void Setup()
        {
            medications = new List<Medication>();
            medications.Add(new Medication() { MedicationID = 1, UserID = 1, MedicationName = "lipitor" });
            medications.Add(new Medication() { MedicationID = 2, UserID = 2, MedicationName = "atorvastatin" });
        }

        [Test]
        public void ShouldMapMedication()
        {
            var med = new Medication();
            med.MedicationID = 1;
            med.MedicationName = "lipitor";

            var med2 = new Medication();
            med.MedicationID = 2;
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
            var controller = new HomeController(_logger);
            var homeLogon = controller.LoginBtn(logon, logon.UserId, logon.Password);
            var result = homeLogon.ToString();
            Assert.IsFalse(result.Contains("Logon"));
        }

        [Test]
        public void ShouldNotLogonUser()
        {
            var logon = new LogonModel();
            logon.UserId = "test";
            logon.Password = "";
            var controller = new HomeController(_logger);
            var homeLogon = controller.LoginBtn(logon, logon.UserId, logon.Password);
            var config = homeLogon.ToString();
            Assert.IsFalse(config.Contains("Index"));
        }
    }
}