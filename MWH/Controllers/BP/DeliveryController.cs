using MWH.Service.BP;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWH.Controllers.BP
{
    public class DeliveryController : Controller
    {
        private readonly DeliveryService _service;
        public DeliveryController()
        {
            _service = new DeliveryService();
        }
        // GET: Delivery
        public ActionResult Index()
        {
            var error = TempData["Error"];
            ViewBag.Error = error;

            var lstData = _service.GetData();
            return View(lstData);
        }

        public ActionResult Create()
        {
            _service.ObjDetail.DATE_DELIVERY = DateTime.Now;
            _service.ObjDetail.YEAR = DateTime.Now.Year;
            var lstproduct = _service.GetAllProDuct();
            ViewBag.LstProduct = lstproduct;
            return View(_service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeliveryService service)
        {
            _service.ValidateData();
            if(_service.State == false)
            {
                ViewBag.Error = "Lỗi xuất";
                return View(service);
            }
            else
            {
                _service.CreateDelivery(service);
            }
            return View();
        }
    }
}