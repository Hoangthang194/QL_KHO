using MWH.Core.Entities;
using MWH.Repository.Implement;
using MWH.Repository.Interface;
using MWH.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Service.MD
{
    public class EmployeeService : GenericService<T_MD_EMPLOYEE, EmployeeRepo>
    {
        public override void GetAll()
        {
            try
            {
                ObjList = UnitOfWork.Repository<EmployeeRepo>().Queryable().Where(x=>x.IS_DELETE == false).ToList();
                this.State = true;
            }
            catch
            {
                this.State = false;
            }
        }
        public override void Delete(string id)
        {
            try
            {
                ObjDetail = UnitOfWork.Repository<EmployeeRepo>().Queryable().FirstOrDefault(x => x.ID_EMPLOYEE == id);
                ObjDetail.IS_DELETE = true;
                this.Update();
                this.State = true;
            }
            catch(Exception ex)
            {
                this.State = false;
            }
        }

        public override void Create()
        {
            try
            {
                this.GetAll();
                var isHave = ObjList.Any(x => x.CODE == ObjDetail.CODE);
                if (isHave)
                {
                    this.State = false;
                }
                else
                {
                    base.Create();
                    this.State = true;
                }
            }
            catch
            {

            }
        }
    }
}