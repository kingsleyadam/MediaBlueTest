using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaBlueTest.Models
{
    public class SessionSubmitScale
    {
        public int SessionSubmitScaleId { get; set; }
        public virtual SessionSubmit SessionSubmit { get; set; }
        public int SessionSubmitId { get; set; }
        public virtual Scale Scale { get; set; }
        public int ScaleId { get; set; }
        public virtual Image Image { get; set; }
        public int ImageId { get; set; }
    }
}