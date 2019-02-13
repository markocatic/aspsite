using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspSite.BusinessLogic.Dto
{
    public class WholeUserDto : BaseDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        //public RoleDto Role { get; set; }
        public string PasswordHash { get; set; }

    }
}