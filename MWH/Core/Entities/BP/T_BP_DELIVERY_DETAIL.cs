using MWH.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Core.Entities.BP
{
    public class T_BP_DELIVERY_DETAIL : BaseEntity
    {
        public virtual string ID_DELIVERY{ get; set; }
        public virtual string ID_PRODUCT { get; set; }
        public virtual decimal? PRICE_DELIVERY { get; set; }
        public virtual int? NUMBER_DELIVERY{ get; set; }

        public virtual T_BP_DELIVERY delivery{ get; set; } = new T_BP_DELIVERY();
        public virtual List<T_MD_PRODUCT> Products { get; set; } = new List<T_MD_PRODUCT>();

    }
}