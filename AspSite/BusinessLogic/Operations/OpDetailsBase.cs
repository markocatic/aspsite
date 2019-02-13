using AspSite.BusinessLogic.Dto;
using AspSite.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspSite.BusinessLogic.Operations
{
    public class OpDetailsBase
    {
        //public override OperationResult Execute(AspSiteBazaEntities entities,int )
        //{
        //    IEnumerable<SingleDto> ieSingle =
        //        from s in entities.Products
        //        select new SingleDto
        //        {
        //            Id = s.product_id,
        //            Description = s.description,
        //            Header = s.header,
        //            Pictures = (from pic in s.Pictures
        //                        select new PictureDto
        //                        {
        //                            Alt = pic.alt,
        //                            Src = pic.src,
        //                            Id = pic.picture_id
        //                        }).ToList()
        //        };

        //    SingleDto[] single = ieSingle.ToArray();
        //    OperationResult result = new OperationResult();
        //    result.Items = single;
        //    result.Status = true;
        //    return result;
        //}
    }
}