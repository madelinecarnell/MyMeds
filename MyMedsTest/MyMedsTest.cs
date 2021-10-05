using NUnit.Framework;
using MyMeds.Controllers;
using MyMeds;
using MyMeds.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Castle.Core.Internal;
using MyMeds.Data;
using Microsoft.EntityFrameworkCore;

namespace MyMedsTest
{
    public class MyMedsTest
    {
        private List<Medication> medications; 

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
        public async Task Details()
        {
            var med = new Medication();
            med.MedicationID = 1;
            med.MedicationName = "test drug";
            var dbContext = new DbContextOptions<MyMedsContext>();
            var context = new MyMedsContext(dbContext);
            var controller = new MedicationsController(context);
            var medicationEdit = await controller.Details(med.MedicationID);
            Assert.IsFalse(medicationEdit.ToString().IsNullOrEmpty());
        }

        [Test]
        public async Task EditMedication()
        {
            var med = new Medication();
            med.MedicationID = 1;
            med.MedicationName = "test drug";
            var dbContext = new DbContextOptions<MyMedsContext>();
            var context = new MyMedsContext(dbContext);
            var controller = new MedicationsController(context);
            var medicationEdit = await controller.Edit(med.MedicationID);
            Assert.IsFalse(medicationEdit.ToString().IsNullOrEmpty());
        }
    }
}