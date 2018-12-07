using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Sample ID")]
        public int SampleID { get; set; }
        [DisplayName("LT Number")]
        public int? LTNumber { get; set; }
        [DisplayName("Sequence Code")]
        public int? SeqCode { get; set; }
        [DisplayName("Assay ID")]
        public int AssayID { get; set; }
        [DisplayName("Sample Name")]
        [Required]
        public string SampleName { get; set; }
        [DisplayName("Sample Quantity (mg)")]
        [Required]
        public int Quantity { get; set; }
        [DisplayName("Date Arrived")]
        public DateTime? DateArrived { get; set; }
        [DisplayName("Received By")]
        public string ReceivedBy { get; set; }
        [DisplayName("Due Date")]
        public DateTime? DueDate { get; set; }
        public string Appearance { get; set; }
        [DisplayName("Weight By Client")]
        [Required]
        public int WeightByClient { get; set; }
        [DisplayName("Molecular Mass")]
        public int? MolMass { get; set; }
        [DisplayName("Confirmation Date Time")]
        public DateTime? ConfirmationDTTM { get; set; }
        [DisplayName("Actual Weight")]
        public int? ActualWeight { get; set; }
        [DisplayName("Maximum Tolerated Dose(MTD)")]
        public int? MTD { get; set; }
        [DisplayName("Order ID")]
        public int? OrderID { get; set; }

        public virtual WorkOrder WorkOrder { get; set; }
        public virtual Assay Assay { get; set; }
        public virtual ICollection<TestTube> TestTubes { get; set; }

    }
}