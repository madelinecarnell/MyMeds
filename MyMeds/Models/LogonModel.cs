using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyMeds.Models
{
    public class LogonModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Password must contain minimum eight characters, one letter, and one number.")]
        public string Password { get; set; }
    }
}
