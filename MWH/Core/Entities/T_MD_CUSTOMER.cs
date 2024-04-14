using MWH.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Core.Entities
{
    public class T_MD_CUSTOMER: BaseEntity
    {
        public virtual string ID_CUSTOMER { get; set; }
        public virtual string NAME_CUSTOMER { get; set; }
        public virtual string ADDRESS_CUSTOMER { get; set; }
        public virtual string PHONE_CUSTOMER { get; set; }
    }
}