using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaBlueTest.Models
{
    public class UserInformation
    {
        public int UserInformationId { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Fullname
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public virtual ApplicationUser AppUser { get; set; }
        public string ApplicationUserID { get; set; }
    }
}