using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWest.Models
{
    [Table("Assay")]
    public class Assay
    {
        [Key]
        [DisplayName("Assay ID")]
        public int AssayID { get; set; }
        [DisplayName("Assay Name")]
        public string AssayName { get; set; }
        [DisplayName("Assay Protocol")]
        public string AssayProtocol { get; set; }
        [DisplayName("Literature Reference")]
        public string LiteratureReference { get; set; }
        [DisplayName("Estimated Days to Complete")]
        public int EstimatedDays { get; set; }

        public virtual ICollection<Sample> Samples { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}