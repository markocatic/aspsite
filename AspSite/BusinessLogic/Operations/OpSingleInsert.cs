using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspSite.BusinessLogic.Dto.Operations;
using AspSite.DataLayer;
using Single = AspSite.DataLayer.Single;

namespace AspSite.BusinessLogic.Operations
{
    public class OpSingleInsert : OpSingleBase
    {

        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            Product sing = new Product();
            sing.header = Dto.Header;
            sing.description = this.Dto.Description;
            foreach (var picture in this.Dto.Pictures)
            {
                Picture p = new Picture
                {
                    alt = picture.Alt,
                    src = picture.Src
                };
                sing.Pictures.Add(p);
            }

            entities.Products.Add(sing);
            entities.SaveChanges();
            return base.Execute(entities);
        }
    }
}