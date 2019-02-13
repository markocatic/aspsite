using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspSite.BusinessLogic.Dto;
using AspSite.DataLayer;

namespace AspSite.BusinessLogic.Operations
{
    public class OpMessageBase : Operation
    {
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            IEnumerable<MessageDto> ieMessage =
                from m in entities.Contacts
                select new MessageDto
                {
                    Message = m.message,
                    Website = m.website,
                    Email = m.email
                };
            OperationResult result = new OperationResult();
            result.Status = true;
            result.Items = ieMessage.ToArray();
            return result;
        }
    }

    public class OpMessageInsert : OpMessageBase
    {
        public MessageDto Dto = new MessageDto();
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            Contact contact = new Contact();
            contact.email = this.Dto.Email;
            contact.message = this.Dto.Message;
            contact.website = this.Dto.Website;

            entities.Contacts.Add(contact);
            entities.SaveChanges();

            return base.Execute(entities);
        }
    }
}