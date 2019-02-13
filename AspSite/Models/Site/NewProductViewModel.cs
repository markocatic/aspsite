using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AspSite.Filter;

namespace AspSite.Models.Site
{
    public class NewProductViewModel
    {
        [Required]
        [Display(Name = "Review Name")]
        public string Header { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [ValidateImageFilter]
        public HttpPostedFileBase Pictures { get; set; }
    }
}