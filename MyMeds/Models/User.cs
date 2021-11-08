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


        [Display(Name = "Prescriber Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone Number")]
        public string PrescriberPhone { get; set; }
       
        public string Pharmacy { get; set; }
        
        [Display(Name = "Pharmacy Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone Number")]
        public string PharmacyPhone { get; set; }

        public ICollection<MedicationModel> Medications { get; set; }
    }
}
