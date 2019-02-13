using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspSite.BusinessLogic.Dto;
using AspSite.DataLayer;

namespace AspSite.BusinessLogic.Operations
{
    public class OpEditUserBase : Operation
    {
        public string id;
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            IEnumerable<UserDetailsDto> ieUsers =
                from i in entities.AspNetUsers
                where i.Id == this.id
                select new UserDetailsDto
                {
                    UserName = i.UserName,
                    Email = i.Email,
                    PasswordHash = i.PasswordHash

                };
            UserDetailsDto[] user = ieUsers.ToArray();
            OperationResult result = new OperationResult();
            result.Status = true;
            result.Items = user;
            return result;
        }
    }
}