using MWH.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Core.Entities
{
    public class T_MD_SUPPLIER : BaseEntity
    {
        public virtual string ID_SUPPLIER {  get; set; }
        public virtual string NAME_SUPPLIER { get; set; }
        public virtual string ADDRESS_SUPPLIER { get; set; }
        public virtual string PHONE_SUPPLIER { get; set; }
        public virtual string EMAIL_SUPPLIER { get; set; }


    }
}