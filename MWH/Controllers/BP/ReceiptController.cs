using MWH.Service.BP;
using MWH.Service.MD;
using NPOI.OpenXmlFormats.Dml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWH.Controllers.BP
{
    public class ReceiptController : Controller
    {
        private readonly ReceiptService _service;
        public ReceiptController()
        {
            _service = new ReceiptService();
        }
        // GET: Receipt
        public ActionResult Index()
        {
            var error = TempData["Error"];
            ViewBag.Error = error;

            var lstData = _service.GetData();
            return View(lstData);
        }

        public ActionResult DownloadExcel()
        {
            MemoryStream outFileStream = new MemoryStream();
            var path = Server.MapPath("~/TemplateExcel/Template_Phieu_Nhap.xlsx");
            _service.ExportExcel(ref outFileStream, path);
            if(_service.State == false)
            {
                TempData["Error"] = "Lỗi khi tải file";
                return RedirectToAction("Index");
            }
            return File(outFileStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Biểu mẫu phiếu nhập.xlsx");
        }

        public ActionResult ImportExcel() {
            _service.ObjDetail.DATE_RECEIPT = DateTime.Now;
            _service.ObjDetail.YEAR = DateTime.Now.Year;
            return View(_service);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ImportExcel(ReceiptService service)
        {
            if (Request.Files.Count == 0)
            {
                service.State = false;
                service.ErrorMessage = "Hãy chọn file excel!";
            }
            else if (Request.Files.Count > 1)
            {
                service.State = false;
                service.ErrorMessage = "Chỉ được phép chọn 1 file excel!";
            }
            else
            {
                service.ImportExcel(Request, service);
            }
            var error = string.Empty;
            if(service.State == false)
            {
                error = "Lỗi khi nhập sản phẩm";
                ViewBag.Error = error;
                return View(_service);
            }
            else
            {
                TempData["Error"] = false;
                return RedirectToAction("Index");
            };
        }

        public ActionResult Update(string id)
        {
            ViewBag.Error = "";
            _service.Get(id);
            return View(_service);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ReceiptService service)
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
                    ViewBag.Error = "Lỗi câp nhật loại sản phẩm";
                    return View(service);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi câp nhật loại sản phẩm";
                return View(service);
            }
        }

        public ActionResult Detail(string id)
        {
            _service.Get(id);
            var data = _service.GetDataDetail();
            return View(data);
        }
    }
}