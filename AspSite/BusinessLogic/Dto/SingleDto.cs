using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspSite.BusinessLogic.Dto
{
    public class SingleDto : BaseDto
    {
        public List<PictureDto> Pictures { get; set; }
        public string Description { get; set; }
        public string Header { get; set; }
    }
}