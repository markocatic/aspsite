using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspSite.BusinessLogic;
using AspSite.BusinessLogic.Dto;
using AspSite.BusinessLogic.Operations;

namespace AspSite.Areas.Admin
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        OperationManager _manager = OperationManager.Singleton;
        // GET: Admin/Role
        public ActionResult Index()
        {
            Operation op = new OpRoleBase();
            OperationResult result = _manager.ExecuteOperation(op);

            return View(result.Items as RoleDto[]);
        }

        // GET: Admin/Role/Details/5
        public ActionResult Details(string id)
        {

            var dto = getInstance(id);
            return View(dto);
        }

        // GET: Admin/Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Role/Create
        [HttpPost]
        public ActionResult Create(RoleDto dto)
        {
           OpRoleInsert insert = new OpRoleInsert();
            insert.Role = dto;
            var result = _manager.ExecuteOperation(insert);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        // GET: Admin/Role/Edit/5
        public ActionResult Edit(string id)
        {
            var dto = getInstance(id);
            return View(dto);
        }

        // POST: Admin/Role/Edit/5
        [HttpPost]
        public ActionResult Edit(RoleDto dto)
        {
            OpRoleUpdate update = new OpRoleUpdate();
            update.Role = dto;
            var result = _manager.ExecuteOperation(update);
            return RedirectToAction("Index");
        }

        // GET: Admin/Role/Delete/5
        public ActionResult Delete(string id)
        {
            var dto = getInstance(id);
            return View(dto);
        }

        // POST: Admin/Role/Delete/5
        [HttpPost]
        public ActionResult Delete(RoleDto dto)
        {
            OpRoleDelete delete = new OpRoleDelete();
            delete.Uuid = dto.UUID;
            var result = _manager.ExecuteOperation(delete);
            return RedirectToAction("Index");
        }

        private RoleDto getInstance(string id)
        {
            OpRoleBase op = new OpRoleBase();
            op.Criteria.Uuid = id;
            var result = _manager.ExecuteOperation(op);
            RoleDto dto = result.Items[0] as RoleDto;
            return dto;
        }
    }
}
