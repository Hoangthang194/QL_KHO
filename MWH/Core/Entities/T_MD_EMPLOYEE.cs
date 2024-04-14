using MWH.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Core.Entities
{
    public class T_MD_EMPLOYEE : BaseEntity
    {
        public virtual string ID_EMPLOYEE { get; set; }
        public virtual string NAME_EMPLOYEE { get; set; }
        public virtual string PHONE_EMPLOYEE { get; set; }
        public virtual string EMAIL { get; set; }
        public virtual string ID_WAREHOUSE { get; set; }


    }
}