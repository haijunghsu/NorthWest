using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWest.Models
{
    [Table("Technician")]
    public class Technician
    {
        [Key]
        public int TechnicianID { get; set; }
        public string TechName { get; set; }
        public int HourlyWage { get; set; }
        public string TechEmail { get; set; }
        public string TechPhone { get; set; }

    }
}