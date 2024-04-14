using MWH.Core.Entities;
using MWH.Models;
using MWH.Repository.Implement;
using MWH.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Service.MD
{
    public class ProductService : GenericService<T_MD_PRODUCT, ProductRepo>
    {
        public override void Delete(string id)
        {
            try
            {
                var number = UnitOfWork.Repository<ProductRepo>().Queryable().FirstOrDefault(x => x.ID_PRODUCT == id).NUMBER_PRODUCT;
                if (number != 0 && number != null)
                {
                    this.State = false;
                }
                else
                {
                    ObjDetail = UnitOfWork.Repository<ProductRepo>().Queryable().FirstOrDefault(x => x.ID_PRODUCT== id);
                    ObjDetail.IS_DELETE = true;
                    this.Update();
                    this.State = true;
                }
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

        public List<ViewDataProductModel> GetData()
        {
            try
            {
                var data = new List<ViewDataProductModel>();
                this.GetAll();
                foreach(var item  in ObjList)
                {
                    var dataItem = new ViewDataProductModel
                    {
                        ID_PRODUCT = item.ID_PRODUCT,
                        CODE = item.CODE,
                        NAME_PRODUCT = item.NAME_PRODUCT,
                        NUMBER_PRODUCT = item.NUMBER_PRODUCT,
                        NUMBER_PRODUCT_TODAY = item.NUMBER_PRODUCT_TODAY,
                        UNIT = item.UNIT,
                        NAME_TYPE = UnitOfWork.Repository<TypeRepo>().Queryable().FirstOrDefault(x => x.ID_TYPE == item.ID_TYPE && x.IS_DELETE == false )?.NAME_TYPE,
                    };
                    data.Add(dataItem);
                }
                return data;
            }
            catch
            {
                return new List<ViewDataProductModel>();
            }
        }
    }
}