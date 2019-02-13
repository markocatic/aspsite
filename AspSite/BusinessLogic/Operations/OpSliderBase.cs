using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspSite.DataLayer;
using AspSite.BusinessLogic.Dto;

namespace AspSite.BusinessLogic.Operations
{
    public class OpSliderBase : Operation
    {
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            SliderDto dto = new SliderDto();
            IEnumerable<PictureDto> iePictures =
                from p in entities.Sliders
                select new PictureDto
                {
                    Alt = p.Picture.alt,
                    Src = p.Picture.src
                };
            dto.Pictures = iePictures.ToList();
            OperationResult result = new OperationResult();
            result.Status = true;
            result.Items = new BaseDto[1];
            result.Items[0] = dto;
            return result;
        }
    }
}