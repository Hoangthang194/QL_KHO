using MWH.Repository.Common;
using MWH.Repository.Implement;
using MWH.Repository.Implement.BP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWH.App_Code
{
    public class SelectListUtilities
    {
        public class Data
        {
            public string Value { get; set; }
            public string Text { get; set; }
            public string Group { get; set; }

            public override bool Equals(object obj)
            {
                return obj is Data data &&
                       Value == data.Value;
            }

            public override int GetHashCode()
            {
                return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
            }
        }

        public static SelectList GetAllType(bool isAddBlank = true, string selected = "")
        {
            IUnitOfWork UnitOfWork = new NHUnitOfWork();
            var lstData = new List<Data>();
            var lstDomain = UnitOfWork.Repository<TypeRepo>().GetAll().Where(x => x.IS_DELETE == false);
            foreach (var obj in lstDomain)
            {
                lstData.Add(new Data { Value = obj.ID_TYPE, Text = obj.NAME_TYPE });
            }
            return new SelectList(lstData, "Value", "Text", new Data { Value = selected });
        }

        public static SelectList GetAllArea(bool isAddBlank = true, string selected = "")
        {
            IUnitOfWork UnitOfWork = new NHUnitOfWork();
            var lstData = new List<Data>();
            if (isAddBlank)
            {
                lstData.Add(new Data() { 
                    Value = "MB",
                    Text = "Kho hàng miền bắc"
                });
                lstData.Add(new Data()
                {
                    Value = "MT",
                    Text = "Kho hàng miền trung"
                });
                lstData.Add(new Data()
                {
                    Value = "MN",
                    Text = "Kho hàng miền nam"
                });
            }
            return new SelectList(lstData, "Value", "Text", new Data { Value = selected });
        }

        public static SelectList GetAllSupplier(bool isAddBlank = true, string selected = "")
        {
            IUnitOfWork UnitOfWork = new NHUnitOfWork();
            var lstData = new List<Data>();
            var lstDomain = UnitOfWork.Repository<SupplierRepo>().GetAll().Where(x => x.IS_DELETE == false);
            foreach (var obj in lstDomain)
            {
                lstData.Add(new Data { Value = obj.ID_SUPPLIER, Text = obj.NAME_SUPPLIER });
            }
            return new SelectList(lstData, "Value", "Text", new Data { Value = selected });
        }

        public static SelectList GetAllCustomer(bool isAddBlank = true, string selected = "")
        {
            IUnitOfWork UnitOfWork = new NHUnitOfWork();
            var lstData = new List<Data>();
            var lstDomain = UnitOfWork.Repository<CustomerRepo>().GetAll().Where(x => x.IS_DELETE == false);
            foreach (var obj in lstDomain)
            {
                lstData.Add(new Data { Value = obj.ID_CUSTOMER, Text = obj.NAME_CUSTOMER });
            }
            return new SelectList(lstData, "Value", "Text", new Data { Value = selected });
        }

        public static SelectList GetAllEmployee(bool isAddBlank = true, string selected = "")
        {
            IUnitOfWork UnitOfWork = new NHUnitOfWork();
            var lstData = new List<Data>();
            var lstDomain = UnitOfWork.Repository<EmployeeRepo>().GetAll().Where(x=>x.IS_DELETE == false);
            foreach (var obj in lstDomain)
            {
                lstData.Add(new Data { Value = obj.ID_EMPLOYEE, Text = obj.CODE + " - " +  obj.NAME_EMPLOYEE });
            }
            return new SelectList(lstData, "Value", "Text", new Data { Value = selected });
        }

        public static SelectList GetAllUnit(bool isAddBlank = true, string selected = "")
        {
            IUnitOfWork UnitOfWork = new NHUnitOfWork();
            var lstData = new List<Data>();
            var lstDomain = UnitOfWork.Repository<UnitRepo>().GetAll().Where(x => x.IS_DELETE == false);
            foreach (var obj in lstDomain)
            {
                lstData.Add(new Data { Value = obj.ID_UNIT, Text = obj.CODE + " - " + obj.NAME_UNIT });
            }
            return new SelectList(lstData, "Value", "Text", new Data { Value = selected });
        }
        public static SelectList GetAllWareHouse(bool isAddBlank = true, string selected = "")
        {
            IUnitOfWork UnitOfWork = new NHUnitOfWork();
            var lstData = new List<Data>();
            var lstDomain = UnitOfWork.Repository<WarehouseRepo>().GetAll().Where(x => x.IS_DELETE == false);
            foreach (var obj in lstDomain)
            {
                lstData.Add(new Data { Value = obj.CODE, Text = obj.NAME_WAREHOUSE });
            }
            return new SelectList(lstData, "Value", "Text", new Data { Value = selected });
        }

        public static SelectList GetAllOrg(bool isAddBlank = true, string selected = "")
        {
            IUnitOfWork UnitOfWork = new NHUnitOfWork();
            var lstData = new List<Data>();
            var lstDomain = UnitOfWork.Repository<OrgRepo>().GetAll().Where(x => x.IS_DELETE == false);
            foreach (var obj in lstDomain)
            {
                lstData.Add(new Data { Value = obj.CODE, Text =  obj.NAME});
            }
            return new SelectList(lstData, "Value", "Text", new Data { Value = selected });
        }
    }
}