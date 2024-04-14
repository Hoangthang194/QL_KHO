using MWH.Core.Entities;
using MWH.Service.MD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MWH.Controllers
{
    public class CategoryController : Controller
    {
        private readonly WarehouseService _service;
        public CategoryController()
        {
            _service = new WarehouseService();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexWareHouse()
        {
           _service.GetAll();
            ViewBag.Data = _service.ObjList;
            ViewBag.Error = false;
            return View(_service);
        }
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View(_service);
        }

        [HttpPost]

        public ActionResult Create(WarehouseService service)
        {
            try
            {
                var id = Guid.NewGuid().ToString();
                service.ObjDetail.ID_WAREHOUSE = id;
                service.Create();
                if (service.State)
                {
                    ViewBag.Error = false;
                    return View(service);
                }
                else
                {
                    ViewBag.Error = "Lỗi thêm kho hàng";
                    return View(service);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi thêm kho hàng";
                    return View(service);
            }
        }


        public ActionResult Delete(string warehouseID)
        {
            try
            {
                _service.Delete(warehouseID);
                if (_service.State)
                {
                    return Json(new { success = true, message = "Xoá thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Có lỗi xảy ra khi xóa" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra khi xóa kho hàng: " + ex.Message });
            }
        }

        public ActionResult Update(string id)
        {
            ViewBag.Error = "";
            _service.Get(id);
             return View(_service);
        }
        [HttpPost]
        public ActionResult Update(WarehouseService service)
        {
            try
            {
                service.Update();
                if (service.State)
                {
                    ViewBag.Error = false;
                    return View(_service);
                }
                else
                {
                    ViewBag.Error = "Lỗi câp nhật kho hàng";
                    return View(service);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi câp nhật kho hàng";
                return View(service);
            }
        }



    }
}