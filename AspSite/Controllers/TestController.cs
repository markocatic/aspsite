using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspSite.BusinessLogic;
using AspSite.BusinessLogic.Dto.Operations;

namespace AspSite.Controllers
{
    public class TestController : Controller

    {
        OperationManager _manager = OperationManager.Singleton;
        // GET: Test
        public ActionResult Index()
        {
            OpSingleBase s = new OpSingleBase();
            OperationResult result = _manager.ExecuteOperation(s);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}