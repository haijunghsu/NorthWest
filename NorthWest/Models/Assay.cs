using System;
using System.Collections.Generic;
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
        public int AssayID { get; set; }
        public string AssayName { get; set; }
        public string AssayProtocol { get; set; }
        public string LiteratureReference { get; set; }
        public int EstimatedDays { get; set; }

        public virtual ICollection<Sample> Samples { get; set; }
    }
}