using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthWest.Models
{
    [Table("Test")]
    public class Test
    {
        [Key]
        public int TestID { get; set; }
        public int AssayID { get; set; }
        public string TestName { get; set; }
        public int BasePrice { get; set; } 
        public string TestRequired { get; set; }

        public virtual Assay Assay { get; set; }
        public virtual ICollection<TestTube> TestTubes { get; set; }
        public virtual ICollection<Test_Material> Material_Tests { get; set; }
    }
}