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

namespace ProfileTest
{
    public class ProfileTest
    {
        private List<User> User; 

        [SetUp]
        public void Setup()
        {
            User = new List<User>();
            User.Add(new User() {ID = 1, PharmacyPhone = "8149233563", Pharmacy = "Walmart"});
            User.Add(new User() {ID = 2, PharmacyPhone = "123456789", Pharmacy = "Walgreens" });
            User.Add(new User() {ID =3, PharmacyPhone = "145326578", Pharmacy = "Rite Aid" });
        }

        [Test]
        public void ShouldMapMedication()
        {
            var user = new User();
            user.Pharmacy= "Giant Eagle";
            var user2 = new User();
            user.Pharmacy = "Walmart";
            Assert.AreNotEqual(user, user2);
        }

        [Test]
        public void ShouldCountMultipleProfiles()
        {
            var amount = User.Count();
            bool amountofProfilesEquals = amount.Equals(3);
            Assert.IsTrue(amountofProfilesEquals);
        }


        [Test]
        public async Task Details()
        {
            var user = new User();
            user.ID = 1;
            var dbContext = new DbContextOptions<MyMedsContext>();
            var context = new MyMedsContext(dbContext);
            var controller = new MedicationsController(context);
            var medicationEdit = await controller.Details(user.ID);
            Assert.IsFalse(medicationEdit.ToString().IsNullOrEmpty());
        }

        [Test]
        public async Task EditUser()
        {
            var user = new User();
            user.PharmacyPhone = "8141234567";
            user.ID = 1;
            var dbContext = new DbContextOptions<MyMedsContext>();
            var context = new MyMedsContext(dbContext);
            var controller = new MedicationsController(context);
            var medicationEdit = await controller.Edit(user.ID);
            Assert.IsFalse(medicationEdit.ToString().IsNullOrEmpty());
        }
    }
}