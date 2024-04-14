using MWH.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Core.Entities
{
    public class T_MD_PRODUCT:BaseEntity
    {
        public virtual string ID_PRODUCT { get; set; }
        public virtual string NAME_PRODUCT { get; set; }
        public virtual int? NUMBER_PRODUCT {  get; set; }
        public virtual int? NUMBER_PRODUCT_TODAY { get; set; }

        public virtual string UNIT {  get; set; }
        public virtual string ID_TYPE { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual int? Number_delivery { get; set; }

    }
}