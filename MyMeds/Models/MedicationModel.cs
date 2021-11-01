using System;
using System.ComponentModel.DataAnnotations;

namespace MyMeds.Models
{
    public class MedicationModel
    {
        public int Id { get; set; }
        public int LogonsId { get; set; }
        public string MedicationName { get; set; }
        public string Directions { get; set; }
        public string Prescriber { get; set; }
        public int Refills { get; set; }
        public string Pharmacy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime TimeTaken { get; set; }
    }
}
