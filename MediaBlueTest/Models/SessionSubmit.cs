using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaBlueTest.Models
{
    public class SessionSubmit
    {
        public int SessionSubmitId { get; set; }
        public virtual Session Session { get; set; }
        public string SessionId { get; set; }
        public DateTime SubmitDate { get; set; }
    }
}