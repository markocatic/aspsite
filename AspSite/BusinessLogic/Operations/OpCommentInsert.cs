using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspSite.BusinessLogic.Dto;
using AspSite.DataLayer;

namespace AspSite.BusinessLogic.Operations
{
    public class OpCommentInsert : OpCommentBase
    {
        public CommentDto Comment = new CommentDto();
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            //Comment comment = new Comment();
            //UserDto user = new UserDto();
            //comment.comment_id = this.Comment.Id+1;
            //comment.content = this.Comment.Content;
            //comment.product_id = this.Comment.ProductId;
            //comment.user_id = user.UUID;

            //Comment comment = new Comment
            //{
            //    product_id = 
            //}

            //entities.Comments.Add(comment);
            //entities.SaveChanges();

            return base.Execute(entities);
        }
    }
}