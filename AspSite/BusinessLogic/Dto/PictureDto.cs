using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspSite.BusinessLogic.Dto
{
    public class PictureDto :  BaseDto
    {
        public string Alt { get; set; }
        public string Src { get; set; }
    }
}