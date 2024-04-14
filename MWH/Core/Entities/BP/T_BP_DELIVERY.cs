using MWH.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Core.Entities.BP
{
    public class T_BP_DELIVERY : BaseEntity
    {
        public virtual string ID_DELIVERY { get; set; }
        public virtual string ID_CUSTOMER { get; set; }
        public virtual string ID_SHIPPINE_UNIT { get; set; }

        public virtual DateTime DATE_DELIVERY { get; set; }
        public virtual string ID_EMPLOYEE { get; set; }
        public virtual decimal? AMOUNT { get; set; }
        public virtual int YEAR { get; set; }
        public virtual string Name_Employy { get; set; }
        public virtual string Name_Delivery { get; set; }

        public virtual List<T_BP_DELIVERY_DETAIL> Details { get; set; }

    }
}