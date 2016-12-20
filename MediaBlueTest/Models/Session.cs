using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaBlueTest.Models
{
    public class Session
    {
        [Key]
        public string SessionId { get; set; }
        public virtual ApplicationUser AppUser { get; set; }
        public string ApplicationUserID { get; set; }
    }
}