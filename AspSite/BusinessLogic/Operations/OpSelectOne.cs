using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspSite.DataLayer;

namespace AspSite.BusinessLogic.Dto.Operations
{
    public class OpSelectOne : Operation
    {
        public int id;
      
            public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            IEnumerable<SingleDto> ieSingle =
                from s in entities.Products
                where s.product_id == this.id
                select new SingleDto
                {
                    Id = s.product_id,
                    Description = s.description,
                    Header = s.header,
                    Pictures = (from pic in s.Pictures
                                select new PictureDto
                                {
                                    Alt = pic.alt,
                                    Src = pic.src,
                                    Id = pic.picture_id
                                }).ToList()
                };

            SingleDto[] single = ieSingle.ToArray();
            OperationResult result = new OperationResult();
            result.Items = single;
            result.Status = true;
            return result;
        }
    }
    
}