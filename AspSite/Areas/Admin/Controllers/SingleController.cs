using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspSite.BusinessLogic;
using AspSite.BusinessLogic.Dto;
using AspSite.BusinessLogic.Dto.Operations;
using AspSite.BusinessLogic.Operations;
using AspSite.Models.Site;

namespace AspSite.Areas.Admin.Controllers
{
    public class SingleController : Controller
    {
        OperationManager _manager = OperationManager.Singleton;
        // GET: Admin/Single
        public ActionResult Index()
        {
            OpSingleBase op = new OpSingleBase();
            var result = _manager.ExecuteOperation(op);
            
            return View(result.Items as SingleDto[]);
        }

        // GET: Admin/Single/Details/5
        public ActionResult Details(int id)
        {
            var dto = getInstance(id);
            return View(dto);
        }

        // GET: Admin/Single/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Single/Create
        [HttpPost]
        public ActionResult Create(NewProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //unos u dto
                SingleDto dto = new SingleDto
                {
                    Header = vm.Header,
                    Description = vm.Description,
                    Pictures = new List<PictureDto>()
                };
                //smetanje slika na drive
                string filename = Guid.NewGuid().ToString() + "_" + vm.Pictures.FileName;
                string putanja = Path.Combine(Server.MapPath("~/Content/Images"), filename);
                vm.Pictures.SaveAs(putanja);

                //dodavanje na dto
                dto.Pictures.Add(new PictureDto
                {
                    Alt = "Neki",
                    Src = "Content/Images/" + filename
                });
                OpSingleInsert op = new OpSingleInsert();
                op.Dto = dto;
                var result = _manager.ExecuteOperation(op);
                return RedirectToAction("Index");
            }
            else
            {
                return View(vm);
            }
        }

        // GET: Admin/Single/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Single/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Single/Delete/5
        public ActionResult Delete(int id)
        {
            var dto = getInstance(id);
            return View(dto);
        }

        // POST: Admin/Single/Delete/5
        [HttpPost]
        public ActionResult Delete(SingleDto dto)
        {
            OpSingleDelete delete = new OpSingleDelete();
            delete.Id = dto.Id;
            var result = _manager.ExecuteOperation(delete);
            return RedirectToAction("Index");
        }

        private SingleDto getInstance(int id)
        {
            OpSingleBase op = new OpSingleBase();
            op.Criteria.Id = id;
            var result = _manager.ExecuteOperation(op);
            SingleDto dto = result.Items[0] as SingleDto;
            return dto;
        }
    }
}
