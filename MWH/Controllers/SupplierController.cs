﻿using MWH.Service.MD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWH.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        private readonly SupplierService _service;
        public SupplierController()
        {
            _service = new SupplierService();
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

        public ActionResult Create(SupplierService service)
        {
            try
            {
                var id = Guid.NewGuid().ToString();
                service.ObjDetail.ID_SUPPLIER = id;
                service.Create();
                if (service.State)
                {
                    ViewBag.Error = false;
                    return View(service);
                }
                else
                {
                    ViewBag.Error = "Lỗi thêm nhà cung cấp";
                    return View(service);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi thêm nhà cung cấp";
                return View(service);
            }
        }


        public ActionResult Delete(string SupplierID)
        {
            try
            {
                _service.Delete(SupplierID);
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
                return Json(new { success = false, message = "Có lỗi xảy ra khi xóa nhà cung cấp: " + ex.Message });
            }
        }

        public ActionResult Update(string id)
        {
            ViewBag.Error = "";
            _service.Get(id);
            return View(_service);
        }
        [HttpPost]
        public ActionResult Update(SupplierService service)
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
                    ViewBag.Error = "Lỗi câp nhật nhà cung cấp";
                    return View(service);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi câp nhật nhà cung cấp";
                return View(service);
            }
        }
    }
}