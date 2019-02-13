using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspSite.DataLayer;
using AspSite.BusinessLogic.Dto;

namespace AspSite.BusinessLogic.Operations
{
    public class OpAuthorBase : Operation
    {
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            IEnumerable<AuthorDto> ieAuthor =
                from a in entities.Authors
                select new AuthorDto
                {
                    About = a.about,
                    Id = a.author_id,
                    Name = a.name
                };
            AuthorDto[] author = ieAuthor.ToArray();
            OperationResult op = new OperationResult();
            op.Status = true;
            op.Items = author;
            return op;
        }
    }
}