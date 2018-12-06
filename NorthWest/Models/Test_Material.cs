using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWest.Models
{
    [Table("Test_Material")]
    public class Test_Material
    {
        [Key]
        [Column(Order = 1)]
        public int TestID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int MaterialID { get; set; }

        public virtual Material Material { get; set; }
        public virtual Test Test { get; set; }
    }
}