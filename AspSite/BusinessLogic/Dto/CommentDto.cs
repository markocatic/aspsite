using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspSite.BusinessLogic.Dto
{
    public class CommentDto : BaseDto
    {
        public string Content { get; set; }

        public int ProductId { get; set; }

        public string UserId { get; set; }

        public List<UserDto> User { get; set; }

    }

}