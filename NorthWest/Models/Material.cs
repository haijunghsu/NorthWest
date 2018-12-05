using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWest.Models
{
    [Table("Material")]
    public class Material
    {
        [Key]
        public int MaterialID { get; set; }
        public string MaterialName { get; set; }
    }
}