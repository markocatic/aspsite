using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspSite.BusinessLogic.Dto
{
    public class ContactDto : BaseDto
    {
        public string Number { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}