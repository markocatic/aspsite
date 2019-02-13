using AspSite.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspSite.BusinessLogic
{
    public class OperationManager
    {
        private AspSiteBazaEntities _entiteti = new AspSiteBazaEntities();
        private static OperationManager _instance;
        public static OperationManager Singleton
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OperationManager();
                }
                return _instance;
            }
        }
        private OperationManager() { }

        public OperationResult ExecuteOperation(Operation o)
        {
            OperationResult result;
            try
            {
                result = o.Execute(_entiteti);
            }
            catch (Exception e)
            {
                result = new OperationResult();
                result.Message = e.Message;
                result.Status = false;

            }
            return result;
        }
    }
}