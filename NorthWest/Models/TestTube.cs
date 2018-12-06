using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWest.Models
{
    [Table("TestTube")]
    public class TestTube
    {
        [Key]

        public int TestTubeID { get; set; }
        public int SampleID { get; set; }
        public int TestTubeNo { get; set; }
        public int TechID { get; set; }
        public int TestID { get; set; }
        public int? TotalMaterialCost { get; set; }
        public int HourlyWage { get; set; }
        public int Hours { get; set; }
        public string QuantResult { get; set; }
        public string QualResult { get; set; }
        public string Pass_Fail { get; set; }
        public int TotalCost { get; set; }

        public virtual Sample Sample { get; set; }
        public virtual Test Test { get; set; }
    }
}