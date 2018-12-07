using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("TestTube ID")]
        public int TestTubeID { get; set; }
        [DisplayName("Sample ID")]
        public int SampleID { get; set; }
        [DisplayName("TestTube Number")]
        public int TestTubeNo { get; set; }
        [DisplayName("Technician ID")]
        public int TechID { get; set; }
        [DisplayName("Test ID")]
        public int TestID { get; set; }
        [DisplayName("Total Material Cost")]
        public int? TotalMaterialCost { get; set; }
        [DisplayName("Quantitative Result")]
        public string QuantResult { get; set; }
        [DisplayName("Qualitative Result")]
        public string QualResult { get; set; }
        [DisplayName("Status")]
        public string Pass_Fail { get; set; }
        [DisplayName("Total Cost")]
        public int TotalCost { get; set; }

        public virtual Sample Sample { get; set; }
        public virtual Test Test { get; set; }
    }
}