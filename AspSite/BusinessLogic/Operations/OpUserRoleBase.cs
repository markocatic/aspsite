using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspSite.BusinessLogic.Dto;
using AspSite.DataLayer;

namespace AspSite.BusinessLogic.Operations
{
    public class OpUserRoleBase : Operation
    {
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            IEnumerable<WholeUserDto> ieUsers =
                from u in entities.AspNetUsers
                select new WholeUserDto
                {
                    UserName = u.UserName,
                    Email = u.Email,
                    //Role = new AspNetRole(),

                };
            OperationResult result = new OperationResult();
            result.Items = ieUsers.ToArray();
            result.Status = true;
            return result;
        }
    }
}