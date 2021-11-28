using NUnit.Framework;
using MyMeds.Controllers;
using MyMeds.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using MyMeds.Data;
using Microsoft.EntityFrameworkCore;
using Castle.Core.Internal;
using System.Threading.Tasks;

namespace MyMedsTest
{
    public class MyMedsTest
    {
        //private List<MedicationModel> medications;
        //private readonly ILogger<HomeController> _logger;


        //[SetUp]
        //public void Setup()
        //{
        //    medications = new List<MedicationModel>();
        //    medications.Add(new MedicationModel() { Id = 4, LogonsId = 1, MedicationName = "lipitor" });
        //    medications.Add(new MedicationModel() { Id = 5, LogonsId = 1, MedicationName = "atorvastatin" });
        //}

        //[Test]
        //public void ShouldMapMedication()
        //{
        //    var med = new MedicationModel();
        //    med.Id = 1;
        //    med.MedicationName = "lipitor";

        //    var med2 = new MedicationModel();
        //    med.Id = 2;
        //    Assert.AreNotEqual(med, med2);
        //}

        //[Test]
        //public void ShouldCountListofMeds()
        //{
        //    var amount = medications.Count();
        //    bool amountOfMeds = amount.Equals(2);
        //    Assert.IsTrue(amountOfMeds);
        //}

        //[Test]
        //public void ShouldLogonUser()
        //{
        //    var logon = new LogonModel();
        //    logon.UserId = "MaddieCarnell";
        //    logon.Password = "Maddie1";
        //    var controller = new HomeController(_logger);
        //    var homeLogon = controller.LoginBtn(logon, logon.UserId, logon.Password);
        //    var result = homeLogon.ToString();
        //    Assert.IsFalse(result.Contains("Logon"));
        //}

        //[Test]
        //public void ShouldNotLogonUser()
        //{
        //    var logon = new LogonModel();
        //    logon.UserId = "test";
        //    logon.Password = "";
        //    var controller = new HomeController(_logger);
        //    var homeLogon = controller.LoginBtn(logon, logon.UserId, logon.Password);
        //    var config = homeLogon.ToString();
        //    Assert.IsFalse(config.Contains("Index"));
        //}


        //[Test]
        //public async Task Details()
        //{
        //    var med = new MedicationModel();
        //    med.Id = 1;
        //    med.MedicationName = "test drug";
        //    var dbContext = new DbContextOptions<MyMedsContext>();
        //    var context = new MyMedsContext(dbContext);
        //    var controller = new MedicationsController(context);
        //    var medicationEdit = await controller.Details(med.Id);
        //    Assert.IsFalse(medicationEdit.ToString().IsNullOrEmpty());
        //}

        //[Test]
        //public async Task EditMedication()
        //{
        //    var med = new MedicationModel();
        //    med.Id = 1;
        //    med.MedicationName = "test drug";
        //    var dbContext = new DbContextOptions<MyMedsContext>();
        //    var context = new MyMedsContext(dbContext);
        //    var controller = new MedicationsController(context);
        //    var medicationEdit = await controller.Edit(med.Id);
        //    Assert.IsFalse(medicationEdit.ToString().IsNullOrEmpty());
        //}
    }
}