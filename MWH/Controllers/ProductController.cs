using MWH.Service.MD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWH.Controllers
{
    public class ProductController : Controller
    {


        private readonly ProductService _service;
        public ProductController()
        {
            _service = new ProductService();
        }
        // GET: Product
        public ActionResult Index()
        {
            var lstdata = _service.GetData();
            ViewBag.Data = lstdata;
            return View(_service);
        }

        public ActionResult Delete(string ProductID)
        {
            try
            {
                _service.Delete(ProductID);
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
                return Json(new { success = false, message = "Có lỗi xảy ra khi xóa sản phẩm: " + ex.Message });
            }
        }

        public ActionResult Update(string id)
        {
            ViewBag.Error = "";
            _service.Get(id);
            return View(_service);
        }
        [HttpPost]
        public ActionResult Update(ProductService service)
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
                    ViewBag.Error = "Lỗi câp nhật sản phẩm";
                    return View(service);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi câp nhật sản phẩm";
                return View(service);
            }
        }
    }
}