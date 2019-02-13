using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspSite.BusinessLogic;
using AspSite.BusinessLogic.Dto;
using AspSite.BusinessLogic.Operations;
using AspSite.Models.Site;

namespace AspSite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private OperationManager _manager = OperationManager.Singleton;
        // GET: Admin/User
        public ActionResult Index()
        {
            OpUserBase user = new OpUserBase();
            OperationResult result = _manager.ExecuteOperation(user);

            return View(result.Items as UserDetailsDto[]);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(string id)
        {
            var dto = getInstance(id);
            return View(dto);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            ViewBag.roles = _manager.ExecuteOperation(new OpRoleBase()).Items as RoleDto[];
            return View();
        }

        // POST: Admin/User/Create
        [HttpPost]
        public ActionResult Create(UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                UserDetailsDto dto = new UserDetailsDto
                {
                    
                    Email = vm.Email,
                    //Role = new RoleDto {UUID = vm.RoleId},
                    UserName = vm.UserName,
                    PasswordHash = vm.PasswordHash
                };

                OpUserInsert op = new OpUserInsert();
                op.User = dto;
                var result = _manager.ExecuteOperation(op);
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.roles = _manager.ExecuteOperation(new OpRoleBase()).Items as RoleDto[];
                return View(vm);
            }

        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(string id)
        {
            var dto = getInstance(id);
            return View(dto);
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserDetailsDto dto)
        {
           OpUserUpdate update = new OpUserUpdate();
           update.User = dto;
            var result = _manager.ExecuteOperation(update);
            return RedirectToAction("Index");
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(string id)
        {
            var dto = getInstance(id);
            return View(dto);
        }

        // POST: Admin/User/Delete/5
        [HttpPost]
        public ActionResult Delete(UserDetailsDto dto)
        {
            OpUserDelete delet = new OpUserDelete();
            delet.Uuid = dto.UUID;
            var result = _manager.ExecuteOperation(delet);
            return RedirectToAction("Index");
        }

        private UserDetailsDto getInstance(string id)
        {
            OpUserBase op = new OpUserBase();
            op.Criteria.Uuid = id;
            var result = _manager.ExecuteOperation(op);
            UserDetailsDto dto = result.Items[0] as UserDetailsDto;
            return dto;

        }
    }
}
