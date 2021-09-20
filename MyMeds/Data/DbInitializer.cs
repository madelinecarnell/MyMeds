using MyMeds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMeds.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MyMedsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
            new User{UserName="Carson",Prescriber="Alexander",PrescriberPhone="814-578-9999",Pharmacy="Giant Eagle",PharmacyPhone="814-777-7852"},
            new User{UserName="Meredith",Prescriber="Alexander",PrescriberPhone="814-578-9999",Pharmacy="Walmart",PharmacyPhone="814-789-5642"},
            new User{UserName="Arturo",Prescriber="Alexander",PrescriberPhone="814-578-9999",Pharmacy="Walgreens",PharmacyPhone="814-789-5667"},
            };
            foreach (User s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            var medications = new Medication[]
            {
            new Medication{UserID=1,MedicationName="Allopurinol",Directions="Take 2 Daily in Morning",Prescriber="Alexander",Refills=2,Pharmacy="",TimeTaken=DateTime.Parse("2021-09-01")},
            new Medication{UserID=1,MedicationName="Apixaban",Directions="Take 1 in Morning, 1 in Evening",Prescriber="Alexander",Refills=2,Pharmacy="",TimeTaken=DateTime.Parse("2021-09-01")},
            new Medication{UserID=2,MedicationName="Olmesartan",Directions="Take with food, 1 capsule in the Morning",Prescriber="Alexander",Refills=4,Pharmacy="",TimeTaken=DateTime.Parse("2021-09-01")},
            new Medication{UserID=2,MedicationName="Propranolol",Directions="Take 3 capsules throughout the day",Prescriber="Alexander",Refills=1,Pharmacy="",TimeTaken=DateTime.Parse("2021-09-01")},
            new Medication{UserID=3,MedicationName="Metoclopramide",Directions="Take 1 capsule in the Evening before bed",Prescriber="Alexander",Refills=2,Pharmacy="",TimeTaken=DateTime.Parse("2021-09-01")},
            new Medication{UserID=3,MedicationName="Ketoconazole",Directions="Use twice a week or when needed",Prescriber="Alexander",Refills=3,Pharmacy="",TimeTaken=DateTime.Parse("2021-09-01")},
            new Medication{UserID=3,MedicationName="Finasteride",Directions="Take one tablet in the morning with water",Prescriber="Alexander",Refills=2,Pharmacy="",TimeTaken=DateTime.Parse("2021-09-01")}
            };
            foreach (Medication c in medications)
            {
                context.Medications.Add(c);
            }
            context.SaveChanges();
        }
    }
}
