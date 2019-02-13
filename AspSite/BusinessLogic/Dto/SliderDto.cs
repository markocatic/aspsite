using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspSite.BusinessLogic.Dto
{
    public class SliderDto : BaseDto
    {
        public List<PictureDto> Pictures { get; set; }
    }
}