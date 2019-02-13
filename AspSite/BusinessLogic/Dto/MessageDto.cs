using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspSite.BusinessLogic.Dto
{
    public class MessageDto : BaseDto
    {
        public string Email { get; set; }
        public string Website { get; set; }
        public string Message { get; set; }
    }
}