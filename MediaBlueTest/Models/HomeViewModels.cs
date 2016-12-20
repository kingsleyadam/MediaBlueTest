using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaBlueTest.Models
{
    public class HomeViewModel
    {
        public List<Image> ImageList { get; set; }
    }

    public class HomeViewModelSubmit
    {
        public SessionSubmit SessionSubmit { set; get; }
        public List<SessionSubmitScale> SessionSubmitScaleList { get; set; }
    }
}