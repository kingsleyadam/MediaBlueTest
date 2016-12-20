using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediaBlueTest.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        [Display(Name="Image Name")]
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string ImageName { get; set; }
        [Display(Name = "URL")]
        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string ImageURL { get; set; }
        //We need to store the selected scale and available scale items in the view to pass back to the controller, but we don't want to store this in the database. Use the [NotMapped] attribute.
        [NotMapped]
        public List<Scale> ScaleItems { get; set; }
        [NotMapped]
        public int SelectedScaleId { get; set; }
    }
}