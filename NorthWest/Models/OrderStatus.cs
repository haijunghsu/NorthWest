using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NorthWest.Models
{
    public class OrderStatus
    {
        [Required(ErrorMessage = "Please enter the Order ID")]
        public int orderID { get; set; }
        [Required(ErrorMessage = "Please choice a status")]
        public string status { get; set; }
        public DateTime dateupdated { get; set; }
        
        public virtual WorkOrder WorkOrder { get; set; }
    }
}