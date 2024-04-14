using MWH.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Core.Entities
{
    public class T_AD_ORG :BaseEntity
    {
        public virtual string PARENT_CODE { get; set; }
        public virtual string AREA_CODE { get; set; }
        public virtual string ISGROUP { get; set; }
        public virtual string NAME { get; set; }
    }
}