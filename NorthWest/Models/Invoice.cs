using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Invoice ID")]
        public int InvoiceID { get; set; }
        [DisplayName("Date Due")]
        public DateTime? DateDue { get; set; }
        [DisplayName("Early Payment Due")]
        public DateTime? EarlyPmtDue { get; set; }
        [DisplayName("Early Payment Discount")]
        public int? EarlyPmtDiscount { get; set; }
        [DisplayName("Invoice Date")]
        public DateTime? SentAt { get; set; }
        [DisplayName("Order ID")]
        public int? OrderID { get; set; }
        [DisplayName("Invoice Amount")]
        public int? Balance { get; set; }

        public virtual WorkOrder WorkOrder { get; set; }
    }
}