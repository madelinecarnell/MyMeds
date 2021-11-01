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

            if (context.Logons.Any())
            {
                return;   // DB has been seeded
            }

            var logon = new LogonModel[]
            {
                new LogonModel{Id=1,UserId= "MaddieCarnell",Password= "Maddie1", Prescriber = "Deluca", PrescriberPhone = "8192563563",Pharmacy = "Giant Eagle",PharmacyPhone = "8192455345"},
                new LogonModel{Id=2,UserId= "ILoveDogs",Password= "1234", Prescriber = "Deluca", PrescriberPhone = "8192563563",Pharmacy = "Giant Eagle",PharmacyPhone = "8192455345"},
                new LogonModel{Id=3,UserId= "Hazel",Password= "12345", Prescriber = "Deluca", PrescriberPhone = "8192563563",Pharmacy = "Giant Eagle",PharmacyPhone = "8192455345"},

            };
            foreach (var l in logon)
            {
                context.Logons.Add(l);
            }
            context.SaveChanges();

            var medications = new MedicationModel[]
            {
            new MedicationModel{LogonsId=1,MedicationName="Allopurinol",Directions="Take 2 Daily in Morning",Prescriber="Alexander",Refills=2,Pharmacy="",TimeTaken=DateTime.Parse("2021-09-01")},
            new MedicationModel{LogonsId=1,MedicationName="Apixaban",Directions="Take 1 in Morning, 1 in Evening",Prescriber="Alexander",Refills=2,Pharmacy="",TimeTaken=DateTime.Parse("2021-09-01")},
            new MedicationModel{LogonsId=2,MedicationName="Olmesartan",Directions="Take with food, 1 capsule in the Morning",Prescriber="Alexander",Refills=4,Pharmacy="",TimeTaken=DateTime.Parse("2021-09-01")},
            new MedicationModel{LogonsId=2,MedicationName="Propranolol",Directions="Take 3 capsules throughout the day",Prescriber="Alexander",Refills=1,Pharmacy="",TimeTaken=DateTime.Parse("2021-09-01")},
            new MedicationModel{LogonsId=3,MedicationName="Metoclopramide",Directions="Take 1 capsule in the Evening before bed",Prescriber="Alexander",Refills=2,Pharmacy="",TimeTaken=DateTime.Parse("2021-09-01")},
            new MedicationModel{LogonsId=3,MedicationName="Ketoconazole",Directions="Use twice a week or when needed",Prescriber="Alexander",Refills=3,Pharmacy="",TimeTaken=DateTime.Parse("2021-09-01")},
            new MedicationModel{LogonsId=3,MedicationName="Finasteride",Directions="Take one tablet in the morning with water",Prescriber="Alexander",Refills=2,Pharmacy="",TimeTaken=DateTime.Parse("2021-09-01")}
            };
            foreach (MedicationModel c in medications)
            {
                context.Medications.Add(c);
            }
            context.SaveChanges();
        }
    }
}
