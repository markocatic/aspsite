using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspSite.BusinessLogic.Dto
{
    public class UserDetailsDto :  BaseDto
    {
        public string Email { get; set; }
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        public string PasswordShort
        {
            get { return PasswordHash.ToString().SubStringTo(20); }
        }
    }
}