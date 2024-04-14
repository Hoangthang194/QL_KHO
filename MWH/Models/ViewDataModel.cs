using MWH.Core.Entities;
using MWH.Core.Entities.BP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Models
{
    public class ViewDataModel
    {
        public virtual string Id_Receipt { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Name_Employee { get; set; }
        public virtual string Name_Supplier { get; set; }
        public virtual string Id_Type { get; set; }
        public virtual int? Number_receipt { get; set; }

        public virtual decimal? Amount { get; set; }

    }

    public class ViewDataModelDelivery
    {
        public virtual string Id_Delivery { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Name_Employee { get; set; }
        public virtual string Name_Customer{ get; set; }
        public virtual int? Number_delivery{ get; set; }

        public virtual decimal? Amount { get; set; }

    }

    public class ViewDataProductModel
    {
        public virtual string CODE { get; set; }
        public virtual string ID_PRODUCT { get; set; }
        public virtual string NAME_PRODUCT { get; set; }
        public virtual int? NUMBER_PRODUCT { get; set; }
        public virtual int? NUMBER_PRODUCT_TODAY { get; set; }

        public virtual string UNIT { get; set; }
        public virtual string NAME_TYPE { get; set; }
    }

    public class ViewDataDetail
    {
        public T_BP_RECEIPT receipt { get; set; } = new T_BP_RECEIPT();
        public List<T_MD_PRODUCT> products { get; set; } = new List<T_MD_PRODUCT> ();
    }
}