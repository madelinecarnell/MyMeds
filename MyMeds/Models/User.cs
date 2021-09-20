using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMeds.Models
{   
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Prescriber { get; set; }
        public string PrescriberPhone { get; set; }
        public string Pharmacy { get; set; }
        public string PharmacyPhone { get; set; }

        public ICollection<Medication> Medications { get; set; }
    }
}
