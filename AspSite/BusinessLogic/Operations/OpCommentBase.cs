using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspSite.BusinessLogic.Dto;
using AspSite.DataLayer;
using PagedList;

namespace AspSite.BusinessLogic.Operations
{
    public class OpCommentBase : Operation
    {

        public int id;
        
        public CommentDto komentar_prenos = new CommentDto();

        public override OperationResult Execute(AspSiteBazaEntities entities)
        {

            IEnumerable<CommentDto> ieComment =
                from com in entities.Comments
                where com.product_id == this.id
                select new CommentDto
                {
                    Content = com.content,
                    UserId = com.user_id,
                    ProductId = com.product_id,
                    User = (from user in entities.AspNetUsers
                        select new UserDto
                        {
                            UserName = user.UserName
                        }).ToList()
                };
            OperationResult result = new OperationResult();
            CommentDto[] comment = ieComment.ToArray();
            result.Items = comment;
            result.Status = true;
            return result;
        }

        
    }

    public class OpCommentIns : OpCommentBase
    {
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            Comment com = new Comment
            {
                product_id = komentar_prenos.ProductId,
                user_id = komentar_prenos.UserId,
                content = komentar_prenos.Content
            };
            entities.Comments.Add(com);
            entities.SaveChanges();
            return base.Execute(entities);
        }
    }
}