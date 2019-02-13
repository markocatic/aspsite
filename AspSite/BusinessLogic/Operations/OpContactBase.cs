using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspSite.DataLayer;
using AspSite.BusinessLogic.Dto;

namespace AspSite.BusinessLogic.Operations
{
    public class OpContactBase : Operation
    {
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            IEnumerable<ContactDto> ieContact =
                 from c in entities.Finds
                 select new ContactDto
                 {
                     Id = c.find_id,
                     Email = c.email,
                     Address = c.address,
                     Number = c.number
                 };
            ContactDto[] contact = ieContact.ToArray();
            OperationResult result = new OperationResult();
            result.Status = true;
            result.Items = contact;
            return result;
        }
    }
}