using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWest.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DisplayName("Customer ID")]
        public int CustomerID { get; set; }
        [DisplayName("Customer Name")]
        public string CustName { get; set; }
        [DisplayName("Customer Address")]
        public string Address { get; set; }
        [DisplayName("Customer Phone")]
        public string Phone { get; set; }
        [DisplayName("Customer Email")]
        public string Email { get; set; }

        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}