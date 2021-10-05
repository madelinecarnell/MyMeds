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

namespace IntegrationTest
{
    public class IntegrationTest
    {
        private List<User> User;
        private List<Medication> Medication;

        [SetUp]
        public void Setup()
        {
            User = new List<User>();
            User.Add(new User() {ID = 1, PharmacyPhone = "8149233563", Pharmacy = "Walmart"});
            User.Add(new User() {ID = 2, PharmacyPhone = "123456789", Pharmacy = "Walgreens" });
            User.Add(new User() {ID =3, PharmacyPhone = "145326578", Pharmacy = "Rite Aid" });
            Medication = new List<Medication>();
            Medication.Add(new Medication() { MedicationID = 1, UserID = 1, MedicationName = "lipitor" });
            Medication.Add(new Medication() { MedicationID = 2, UserID = 2, MedicationName = "atorvastatin" });

        }

    }
}