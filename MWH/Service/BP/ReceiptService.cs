using MWH.Core.Entities;
using MWH.Core.Entities.BP;
using MWH.Models;
using MWH.Repository.Implement;
using MWH.Repository.Implement.BP;
using MWH.Service.Common;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace MWH.Service.BP
{
    public class ReceiptService : GenericService<T_BP_RECEIPT, ReceiptRepo>
    {
        [Required(ErrorMessage = "Hãy chọn 1 file")]
        public HttpPostedFileBase Files { get; set; }
        public void ExportExcel(ref MemoryStream FileOfStream, string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                IWorkbook templateWorkbook;
                templateWorkbook = new XSSFWorkbook(fs);
                fs.Close();
                ISheet sheet = templateWorkbook.GetSheetAt(0);
                templateWorkbook.Write(FileOfStream);
                this.State = true;
            }
            catch
            {
                this.State = false;
            }
        }

        public void ImportExcel(HttpRequestBase request, ReceiptService service)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (request.Files.Count > 0)
                {
                    // Lấy file từ request
                    var file = request.Files[0];

                    // Kiểm tra xem file có dữ liệu không
                    if (file != null && file.ContentLength > 0)
                    {
                        // Tạo một stream từ file được tải lên
                        using (Stream fileStream = file.InputStream)
                        {
                            // Load file Excel vào một workbook
                            XSSFWorkbook workbook = new XSSFWorkbook(fileStream);

                            // Chọn sheet đầu tiên từ workbook
                            ISheet sheet = workbook.GetSheetAt(0);

                            // Tạo iterator cho rows của sheet
                            var rowEnumerator = sheet.GetRowEnumerator();

                            // Nếu có hàng đầu tiên, thêm các cột vào DataTable
                            if (rowEnumerator.MoveNext())
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    dataTable.Columns.Add();
                                }

                                // Đọc dữ liệu từ các dòng của Excel và thêm vào DataTable
                                while (rowEnumerator.MoveNext())
                                {
                                    IRow row = (IRow)rowEnumerator.Current;
                                    DataRow dataRow = dataTable.NewRow();
                                    for (int i = 0; i < 5; i++)
                                    {
                                        dataRow[i] = row.GetCell(i)?.ToString();
                                    }
                                    dataTable.Rows.Add(dataRow);
                                }
                            }


                        }

                    }

                    var item = new T_BP_RECEIPT
                    {
                        ID_RECEIPT = Guid.NewGuid().ToString(),
                        ID_SUPPLIER = service.ObjDetail.ID_SUPPLIER,
                        DATE_RECEIPT = service.ObjDetail.DATE_RECEIPT,
                        ID_EMPLOYEE = service.ObjDetail.ID_EMPLOYEE,
                        YEAR = service.ObjDetail.YEAR,
                        ID_TYPE = service.ObjDetail.ID_TYPE,
                    };

                    var lstReceiptDetail =new List<T_BP_RECEIPT_DETAIL>();
                    decimal? amount = 0;
                    UnitOfWork.BeginTransaction();
                    for (int i = 2; i < dataTable.Rows.Count; i++)
                    {
                        decimal? price = dataTable.Rows[i][3] != DBNull.Value ? Convert.ToDecimal(dataTable.Rows[i][3]) : (decimal?)null;
                        var product = new T_MD_PRODUCT
                        {
                            ID_PRODUCT = Guid.NewGuid().ToString(),
                            CODE = dataTable.Rows[i][0].ToString().Trim(),
                            NAME_PRODUCT = dataTable.Rows[i][1].ToString().Trim(),
                            NUMBER_PRODUCT = dataTable.Rows[i][2] != DBNull.Value ? Convert.ToInt32(dataTable.Rows[i][2]) : (int?)null,
                            UNIT = dataTable.Rows[i][4].ToString().Trim(),
                            ID_TYPE = service.ObjDetail.ID_TYPE
                        };
                        amount = amount + price * product.NUMBER_PRODUCT;

                        var receiptDetail = new T_BP_RECEIPT_DETAIL
                        {
                            ID_RECEIPT = item.ID_RECEIPT,
                            ID_PRODUCT = product.ID_PRODUCT,
                            PRICE_RECEIPT = price,
                            NUMBER_RECEIPT = dataTable.Rows[i][2] != DBNull.Value ? Convert.ToInt32(dataTable.Rows[i][2]) : (int?)null,
                        };
                        lstReceiptDetail.Add(receiptDetail);
                        UnitOfWork.Repository<ProductRepo>().Create(product);
                    }
                    item.AMOUNT = amount;
                    UnitOfWork.Repository<ReceiptRepo>().Create(item);

                    foreach(var detail in lstReceiptDetail)
                    {
                        UnitOfWork.Repository<ReceiptDetailRepo>().Create(detail);
                    }

                    UnitOfWork.Commit();
                    State = true;
                }
            }
            catch
            {
                UnitOfWork.Rollback();
                State = false;
            }
        }

        public IList<ViewDataModel> GetData()
        {
            try
            {
                var data = new List<ViewDataModel>();
                this.GetAll();
                foreach (var item in ObjList)
                {
                    var number = UnitOfWork.Repository<ReceiptDetailRepo>().Queryable().Where(x => x.ID_RECEIPT == item.ID_RECEIPT).Sum(x=>x.NUMBER_RECEIPT);
                    var dataItem = new ViewDataModel
                    {
                        Id_Receipt = item.ID_RECEIPT,
                        Date = item.DATE_RECEIPT,
                        Name_Employee = UnitOfWork.Repository<EmployeeRepo>().Queryable().FirstOrDefault(x => x.ID_EMPLOYEE == item.ID_EMPLOYEE && x.IS_DELETE == false )?.NAME_EMPLOYEE,
                        Name_Supplier = UnitOfWork.Repository<SupplierRepo>().Queryable().FirstOrDefault(x => x.ID_SUPPLIER == item.ID_SUPPLIER && x.IS_DELETE == false)?.NAME_SUPPLIER,
                        Id_Type = UnitOfWork.Repository<TypeRepo>().Queryable().FirstOrDefault(x => x.ID_TYPE == item.ID_TYPE && x.IS_DELETE == false)?.CODE,
                        Number_receipt = number,
                        Amount = item.AMOUNT,
                    };
                    data.Add(dataItem);
                }
                return data;
            }
            catch(Exception ex)
            {
                State = false;
                return new List<ViewDataModel>();
            }
        }

        public ViewDataDetail GetDataDetail()
        {
            var data = new ViewDataDetail();
            var lstProduct = UnitOfWork.Repository<ReceiptDetailRepo>().Queryable().Where(x => x.ID_RECEIPT == ObjDetail.ID_RECEIPT).Select(x=>x.ID_PRODUCT).ToList();
           foreach(var code in lstProduct)
            {
                var product = UnitOfWork.Repository<ProductRepo>().Queryable().FirstOrDefault(x=>x.ID_PRODUCT == code);
                data.products.Add(product);
            }
            var receipt = UnitOfWork.Repository<ReceiptRepo>().Queryable().FirstOrDefault(x => x.ID_RECEIPT == ObjDetail.ID_RECEIPT);
            receipt.Name_Employy = UnitOfWork.Repository<EmployeeRepo>().Queryable().FirstOrDefault(x => x.ID_EMPLOYEE == receipt.ID_EMPLOYEE)?.NAME_EMPLOYEE;
            receipt.Name_Supplier = UnitOfWork.Repository<SupplierRepo>().Queryable().FirstOrDefault(x => x.ID_SUPPLIER == receipt.ID_SUPPLIER)?.NAME_SUPPLIER;
            receipt.Name_type = UnitOfWork.Repository<TypeRepo>().Queryable().FirstOrDefault(x => x.ID_TYPE == receipt.ID_TYPE)?.NAME_TYPE;
            data.receipt = receipt;
            return data;
        }
    }
}