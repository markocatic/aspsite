using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspSite.Models.Site
{
    public class UserViewModel
    {

        [Display(Name = "Username")]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }
       
        [Display(Name = "Role")]
        public string RoleId { get; set; }
    }
}