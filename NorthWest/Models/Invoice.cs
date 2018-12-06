using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWest.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public DateTime? DateDue { get; set; }
        public DateTime? EarlyPmtDue { get; set; }
        public int? EarlyPmtDiscount { get; set; }
        public DateTime? SentAt { get; set; }
        public int? OrderID { get; set; }
        public int? Balance { get; set; }

        public virtual WorkOrder WorkOrder { get; set; }
    }
}