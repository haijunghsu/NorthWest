using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Test ID")]
        public int TestID { get; set; }
        [DisplayName("Assay ID")]
        public int AssayID { get; set; }
        [DisplayName("Test Name")]
        public string TestName { get; set; }
        [DisplayName("Base Price")]
        public int BasePrice { get; set; }
        [DisplayName("Test Required?")]
        public string TestRequired { get; set; }

        public virtual Assay Assay { get; set; }
        public virtual ICollection<TestTube> TestTubes { get; set; }
        public virtual ICollection<Test_Material> Material_Tests { get; set; }
    }
}