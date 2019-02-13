using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspSite.BusinessLogic;
using AspSite.BusinessLogic.Dto.Operations;
using AspSite.BusinessLogic.Operations;
using AspSite.BusinessLogic.Dto;
using AspSite.Models;
using Microsoft.AspNet.Identity;
using PagedList;

namespace AspSite.Controllers
{
    public class HomeController : Controller
    {
        
        
        private OperationManager _manager = OperationManager.Singleton;
        
        public ActionResult Index()
        {
           

            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            Operation operation = new OpContactBase();
            OperationResult result = _manager.ExecuteOperation(operation);
            ContactDto c = result.Items[0] as ContactDto;

            return View(c);
        }

        public ActionResult Reviews()
        {
            Operation operation = new OpSingleBase();
            OperationResult result = _manager.ExecuteOperation(operation);
            ProductPicViewModel vm = new ProductPicViewModel
            {
                Single = (result.Items as SingleDto[]).ToList()
            };
            
           
            
            return View(vm);
        }

        public ActionResult Single(int id)
        {
            OpSelectOne op = new OpSelectOne();
            OpCommentBase op1 = new OpCommentBase();
            op.id = id;
            op1.id = id;
            OperationResult result = _manager.ExecuteOperation(op);
            OperationResult result1 = _manager.ExecuteOperation(op1);
            ProductPicViewModel pvm = new ProductPicViewModel
            {
                Single = (result.Items as SingleDto[]).ToList(),
                Comment = (result1.Items as CommentDto[]).ToList()
            };
            return View(pvm);
           
        }

        public JsonResult Test(CommentDto dto)
        {


            dto.UserId = User.Identity.GetUserId();
            OpCommentIns op = new OpCommentIns();
            op.komentar_prenos = dto;
            OperationResult result = _manager.ExecuteOperation(op);
            var comment = result.Items;

            //OpRoleBase op = new OpRoleBase();
            //op.Criteria.Name = "Admin";
            //OperationResult result = _manager.ExecuteOperation(op);


            return Json(comment, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult TestInsert(RoleDto dto)
        //{

            

        //    OpRoleInsert op = new OpRoleInsert();
        //    op.Role = dto;
        //    op.Role.UUID = Guid.NewGuid().ToString();
        //    OperationResult result = _manager.ExecuteOperation(op);


        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult TestDelete(string uuid)
        //{



        //    OpRoleDelete op = new OpRoleDelete();
        //    op.Uuid = uuid;
            
        //    OperationResult result = _manager.ExecuteOperation(op);


        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult TestUpdate(RoleDto dto)
        //{



        //    OpRoleUpdate op = new OpRoleUpdate();
        //    op.Role = dto;

        //    OperationResult result = _manager.ExecuteOperation(op);


        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Author()
        {
            Operation operation = new OpAuthorBase();
            OperationResult result = _manager.ExecuteOperation(operation);
            AuthorDto c = result.Items[0] as AuthorDto;
            return View(c);
        }

        public ActionResult Gallery()
        {
            Operation operation = new OpSliderBase();
            OperationResult result = _manager.ExecuteOperation(operation);
            SliderDto sl = result.Items[0] as SliderDto;
            
            return View(sl);
        }

        //public ActionResult ArticlesSide()
        //{
        //    Operation operation = new OpSingleBase();
        //    OperationResult result = _manager.ExecuteOperation(operation);
        //    ProductPicViewModel vm = new ProductPicViewModel
        //    {
        //        Single = (result.Items as SingleDto[]).ToList()
        //    };
        //    return PartialView("_Layout", vm);
        //}


        /*public ActionResult Test2(int id)
        {

            OpUserBase operation = new OpUserBase();
            //operation.id = id;
            OperationResult result = _manager.ExecuteOperation(operation);
            List<UserDto> user = (result.Items as UserDto[]).ToList();
            return View(user);
        }
        */
        
        public ActionResult UserPanel(string sortOrder,string currentFilter, int? page, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "user_desc" : "";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "email_desc" : "Email";



            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            OpUserBase operation = new OpUserBase();
            OperationResult result = _manager.ExecuteOperation(operation);
            List<UserDetailsDto> users = (result.Items as UserDetailsDto[]).ToList();
            IEnumerable<UserDetailsDto> us = users;
            if (!String.IsNullOrEmpty(searchString))
            {
                us = users.Where(s => s.UserName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "user_desc":
                    us = us.OrderByDescending(s => s.UserName);
                    break;
                case "Email":
                    us = us.OrderBy(s => s.Email);
                    break;
                case "email_desc":
                    us = us.OrderByDescending(s => s.Email);
                    break;
                default:
                    us = us.OrderBy(s => s.UserName);
                    break;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(us.ToPagedList(pageNumber,pageSize));
        }

        //public ActionResult FiltherUser(string searchString)
        //{
        //    OpUserBase operation = new OpUserBase();
        //    OperationResult result = _manager.ExecuteOperation(operation);
        //    List<UserDetailsDto> users = (result.Items as UserDetailsDto[]).ToList();
        //    IEnumerable<UserDetailsDto> us = users;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        us = users.Where(s => s.UserName.Contains(searchString));
        //    }
        //    return View("UserPanel",us.ToList());
        //}
        /*
        public ActionResult EditUser(string id)
        {
            OpEditUserBase edit = new OpEditUserBase();
            edit.id = id;
            OperationResult result = _manager.ExecuteOperation(edit);
            UserDetailsDto users = result.Items[0] as UserDetailsDto;
            return View(users);
        }
        */

        //public ActionResult Insert()
        //{
        //    return View();
        //}

        public JsonResult Add(SingleDto dto)
        {
            OpSingleInsert op = new OpSingleInsert();
            op.Dto = dto;
            var result = _manager.ExecuteOperation(op);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Komentar(MessageDto dto)
        {
            OpMessageInsert ins = new OpMessageInsert();
            ins.Dto = dto;
            OperationResult result = _manager.ExecuteOperation(ins);
            var message = result.Items;
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}

