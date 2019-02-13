using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspSite.BusinessLogic
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public string UUID { get; set; }
    }
}