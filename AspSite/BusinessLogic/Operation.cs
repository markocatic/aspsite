using AspSite.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspSite.BusinessLogic
{
    public abstract class Operation
    {
        public abstract OperationResult Execute(AspSiteBazaEntities entities);
    }
}