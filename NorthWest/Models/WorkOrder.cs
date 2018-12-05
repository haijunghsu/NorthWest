using System;
using System.Collections.Generic;
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
        public int OrderID { get; set; }
        public int AgentID { get; set; }
        public int CustomerID { get; set; }
        public int? TestTubeID { get; set; }
        public string PaymentInfo { get; set; }
        public string Comments { get; set; }
        public int DiscountApplied { get; set; }
        public int Deposit { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual SalesAgent SalesAgent { get; set; }
    }
}