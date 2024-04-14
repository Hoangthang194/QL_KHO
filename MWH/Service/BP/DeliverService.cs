using MWH.Core.Entities;
using MWH.Core.Entities.BP;
using MWH.Models;
using MWH.Repository.Implement;
using MWH.Repository.Implement.BP;
using MWH.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace MWH.Service.BP
{
    public class DeliveryService : GenericService<T_BP_DELIVERY, DeliveryRepo>
    {
        public List<T_MD_PRODUCT> lstProduct { get; set; } = new List<T_MD_PRODUCT>();

        public void CreateDelivery(DeliveryService service)
        {
            var item = new T_BP_DELIVERY
            {
                ID_DELIVERY= Guid.NewGuid().ToString(),
                ID_CUSTOMER = service.ObjDetail.ID_DELIVERY,
                DATE_DELIVERY = service.ObjDetail.DATE_DELIVERY,
                ID_EMPLOYEE = service.ObjDetail.ID_EMPLOYEE,
                YEAR = service.ObjDetail.YEAR,
                ID_SHIPPINE_UNIT = service.ObjDetail.ID_SHIPPINE_UNIT
            };
            var lstReceiptDetail = new List<T_BP_RECEIPT_DETAIL>();
            decimal? amount = 0;
            var selectedProducts = service.lstProduct.Where(x => x.IsCheck == true).ToList();
            UnitOfWork.BeginTransaction();
            foreach(var product in selectedProducts)
            {

            }
        }

        public void ValidateData()
        {
            foreach(var item in lstProduct)
            {
                var product = UnitOfWork.Repository<ProductRepo>().Queryable().FirstOrDefault(x => x.ID_PRODUCT == item.ID_PRODUCT);
                if(product?.NUMBER_PRODUCT < item.Number_delivery) {
                    State = false;
                }
            }
        }
        public IList<ViewDataModelDelivery> GetData()
        {
            try
            {
                var data = new List<ViewDataModelDelivery>();
                this.GetAll();
                foreach (var item in ObjList)
                {
                    var number = UnitOfWork.Repository<DeliveryDetailRepo>().Queryable().Where(x => x.ID_DELIVERY == item.ID_DELIVERY).Sum(x => x.NUMBER_DELIVERY);
                    var dataItem = new ViewDataModelDelivery
                    {
                        Id_Delivery= item.ID_DELIVERY,
                        Date = item.DATE_DELIVERY,
                        Name_Employee = UnitOfWork.Repository<EmployeeRepo>().Queryable().FirstOrDefault(x => x.ID_EMPLOYEE == item.ID_EMPLOYEE && x.IS_DELETE == false)?.NAME_EMPLOYEE,
                        Name_Customer = UnitOfWork.Repository<CustomerRepo>().Queryable().FirstOrDefault(x => x.ID_CUSTOMER == item.ID_CUSTOMER && x.IS_DELETE == false)?.NAME_CUSTOMER,
                        Number_delivery = number,
                        Amount = item.AMOUNT,
                    };
                    data.Add(dataItem);
                }
                return data;
            }
            catch (Exception ex)
            {
                State = false;
                return new List<ViewDataModelDelivery>();
            }
        }

        public IList<T_MD_PRODUCT> GetAllProDuct()
        {
            try
            {
                var lstData = UnitOfWork.Repository<ProductRepo>().Queryable().Where(x=>x.IS_DELETE == false).ToList();
                lstProduct = lstData;
                return lstData;
            }
            catch
            {
                return new List<T_MD_PRODUCT>();
            }
        }
    }
}