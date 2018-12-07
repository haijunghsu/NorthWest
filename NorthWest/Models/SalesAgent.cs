using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Sales Agent ID")]
        public int AgentID { get; set; }
        [DisplayName("Sales Agent Name")]
        public string AgentName { get; set; }
        [DisplayName("Sales Agent Salary")]
        public int AgentSalary { get; set; }

        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}