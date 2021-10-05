using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMeds.Models
{
    public class Medication
    {
        public int MedicationID { get; set; }
        public int UserID { get; set; }
        
        [Required(ErrorMessage = "Medication Name is Required")]
        public string MedicationName { get; set; }
        public string Directions { get; set; }
        public string Prescriber { get; set; }
        public decimal Refills { get; set; }
        public string Pharmacy { get; set; }
        public DateTime TimeTaken { get; set; }
    }
}
