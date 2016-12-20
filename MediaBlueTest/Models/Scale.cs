using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediaBlueTest.Models
{
    public class Scale
    {
        public int ScaleId { get; set; }
        public int Weight { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string Name { get; set; }
        public int Order { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string CssClass { get; set; }
    }
}