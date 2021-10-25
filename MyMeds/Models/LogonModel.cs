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
        [Required(ErrorMessage = "Invalid User Name")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
    }
}
