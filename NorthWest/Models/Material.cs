using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Material ID")]
        public int MaterialID { get; set; }
        [DisplayName("Material Name")]
        public string MaterialName { get; set; }
        [DisplayName("Material Cost")]
        public int MaterialCost { get; set; }

        public virtual ICollection<Test_Material> Material_Tests { get; set; }
    }
}