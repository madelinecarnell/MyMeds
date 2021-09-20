﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMeds.Models
{
    public class Medication
    {
        public int MeciationID { get; set; }
        public int UserID { get; set; }
        public string MedicationName { get; set; }
        public string Directions { get; set; }
        public string Prescriber { get; set; }
        public decimal Refills { get; set; }
        public string Pharmacy { get; set; }
        public DateTime TimeTaken { get; set; }
    }
}
