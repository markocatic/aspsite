using AspSite.BusinessLogic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspSite.Models
{
    public class ProductPicViewModel
    {
        public List<SingleDto> Single { get; set; }

        public List<CommentDto> Comment { get; set; }
    }
}