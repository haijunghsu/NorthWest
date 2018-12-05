using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWest.Models
{
    [Table("SalesAgent")]
    public class SalesAgent
    {
        [Key]
        public int AgentID { get; set; }
        public string AgentName { get; set; }
        public int AgentSalary { get; set; }

        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}