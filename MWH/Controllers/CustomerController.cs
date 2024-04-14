using MWH.Service.MD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWH.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _service;
        // GET: Customer
        public CustomerController()
        {
            _service = new CustomerService();
        }
        public ActionResult Index()
        {
            _service.GetAll();
            ViewBag.Data = _service.ObjList;
            return View(_service);
        }

        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View(_service);
        }

        [HttpPost]

        public ActionResult Create(CustomerService service)
        {
            try
            {
                var id = Guid.NewGuid().ToString();
                service.ObjDetail.ID_CUSTOMER = id;
                service.Create();
                if (service.State)
                {
                    ViewBag.Error = false;
                    return View(service);
                }
                else
                {
                    ViewBag.Error = "Lỗi thêm khách hàng";
                    return View(service);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi thêm khách hàng";
                return View(service);
            }
        }


        public ActionResult Delete(string CustomerID)
        {
            try
            {
                _service.Delete(CustomerID);
                if (_service.State)
                {
                    return Json(new { success = true, message = "Xoá khách hàng thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Có lỗi xảy ra khi xóa" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra khi xóa khách hàng: " + ex.Message });
            }
        }

        public ActionResult Update(string id)
        {
            ViewBag.Error = "";
            _service.Get(id);
            return View(_service);
        }
        [HttpPost]
        public ActionResult Update(CustomerService service)
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
                    ViewBag.Error = "Lỗi câp nhật khách hàng";
                    return View(service);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi câp nhật khách hàng";
                return View(service);
            }
        }
    }
}