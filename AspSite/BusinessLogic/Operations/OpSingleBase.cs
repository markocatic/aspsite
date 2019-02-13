using AspSite.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using Single = AspSite.DataLayer.Single;

namespace AspSite.BusinessLogic.Dto.Operations
{
    public class ProductCriteria : SelectCriteria
    {
        public string Name { get; set; }
    }
    public class OpSingleBase : Operation
    {
        public SingleDto Dto { get; set; }
        public ProductCriteria Criteria = new ProductCriteria();
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            IEnumerable<SingleDto> ieSingle =
                from s in entities.Products
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

            if (Criteria.Id != 0)
            {
                ieSingle = ieSingle.Where(r => r.Id == Criteria.Id);
            }

            if (!Criteria.Name.IsNullOrWhiteSpace())
            {
                ieSingle = ieSingle.Where(r => r.Header == Criteria.Name);
            }
                
            SingleDto[] single = ieSingle.ToArray();
            OperationResult result = new OperationResult();
            result.Items = single;
            result.Status = true;
            return result;
        }
    }

    public class OpSingleDelete : OpSingleBase
    {
        public int Id { get; set; }
        public override OperationResult Execute(AspSiteBazaEntities entities)
        {
            //Product single = entities.Products.Find(Id);
            Product single = entities.Products.Where(r => r.product_id == Id).FirstOrDefault();
            if (single != null)
            {
                //entities.Entry(single).State = System.Data.Entity.EntityState.Deleted;
                entities.Products.Remove(single);
                entities.SaveChanges();
                return base.Execute(entities);
            }
            else
            {
                OperationResult result = new OperationResult();
                result.Status = false;
                result.Message = "The post doesn't exist.";
                return result;
            }
        }
    }


}