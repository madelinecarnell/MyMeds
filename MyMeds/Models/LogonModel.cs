using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

namespace MyMeds.Models
{
    public class LogonModel : IdentityUser
    {
        public LogonModel()
        {
            Medications = new HashSet<MedicationModel>();
        }

        public int LoginId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Prescriber { get; set; }
        public string PrescriberPhone { get; set; }
        public string Pharmacy { get; set; }
        public string PharmacyPhone { get; set; }

        public ICollection<MedicationModel> Medications { get; set; }
    }
}
