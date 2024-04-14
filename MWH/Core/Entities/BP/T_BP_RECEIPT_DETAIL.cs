using MWH.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Core.Entities.BP
{
    public class T_BP_RECEIPT_DETAIL : BaseEntity
    {
        public virtual string ID_RECEIPT { get; set; }
        public virtual string ID_PRODUCT { get; set; }
        public virtual decimal? PRICE_RECEIPT { get; set; }
        public virtual int? NUMBER_RECEIPT { get; set; }

        public virtual T_BP_RECEIPT Supplier { get; set; } = new T_BP_RECEIPT();
        public virtual List<T_MD_PRODUCT> Products { get; set; } = new List<T_MD_PRODUCT>();

    }
}