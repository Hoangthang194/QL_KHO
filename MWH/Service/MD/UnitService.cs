﻿using MWH.Core.Entities;
using MWH.Repository.Implement;
using MWH.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Service.MD
{
    public class UnitService : GenericService<T_MD_UNIT, UnitRepo>
    {
        public override void Delete(string id)
        {
            try
            {
                ObjDetail = UnitOfWork.Repository<UnitRepo>().Queryable().FirstOrDefault(x => x.ID_UNIT == id);
                ObjDetail.IS_DELETE = true;
                this.Update();
                this.State = true;
            }
            catch (Exception ex)
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