using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyMeds.Models
{
   
    public class Profile

    {
        [Key]
        public string Prescriber { get; set; }
        public string PrescriberPhone { get; set; }
        public string Pharmacy { get; set; }
        public string PharmacyPhone { get; set; }
    }
}
