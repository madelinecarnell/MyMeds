using System.ComponentModel.DataAnnotations;


namespace MyMeds.Models
{
    public class LogonModel : MedicationModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Invalid User Name")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
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
    }
}
