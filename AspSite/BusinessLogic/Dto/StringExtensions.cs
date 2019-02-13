using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspSite.BusinessLogic.Dto
{
    public static class StringExtensions 
    {
        public static string SubStringTo(this string thatString, int limit)
        {
            if (thatString.Length > limit)
            {
                return thatString.Substring(0, limit);
            }

            return thatString;
        }
    }
}