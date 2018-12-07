using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWest.Models
{
    [Table("WorkOrder")]
    public class WorkOrder
    {
        [Key]
        [DisplayName("Order ID")]
        public int OrderID { get; set; }
        [DisplayName("Agent ID")]
        public int? AgentID { get; set; }
        [DisplayName("Customer ID")]
        public int CustomerID { get; set; }
        [DisplayName("Payment Information")]
        [Required(ErrorMessage = "Please enter your payment information")]
        public string PaymentInfo { get; set; }
        public string Comments { get; set; }
        [DisplayName("Discount Applied")]
        public int? DiscountApplied { get; set; }
        public int? Deposit { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual SalesAgent SalesAgent { get; set; }

        public virtual ICollection<Sample> Samples { get; set; }
    }
}