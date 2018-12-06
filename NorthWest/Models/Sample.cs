using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWest.Models
{
    [Table("Sample")]
    public class Sample
    {
        [Key]
        public int SampleID { get; set; }
        public int? LTNumber { get; set; }
        public int? SeqCode { get; set; }
        public int AssayID { get; set; }
        public string SampleName { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateArrived { get; set; }
        public string ReceivedBy { get; set; }
        public DateTime? DueDate { get; set; }
        public string Appearance { get; set; }
        public int WeightByClient { get; set; }
        public int? MolMass { get; set; }
        public DateTime? ConfirmationDTTM { get; set; }
        public int? ActualWeight { get; set; }
        public int? MTD { get; set; }
        public int? OrderID { get; set; }

        public virtual WorkOrder WorkOrder { get; set; }
        public virtual Assay Assay { get; set; }
        public virtual ICollection<TestTube> TestTubes { get; set; }

    }
}