using MWH.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Core.Entities.BP
{
    public class T_BP_RECEIPT:BaseEntity
    {
        public virtual string ID_RECEIPT { get;set; }
        public virtual string ID_SUPPLIER { get;set; }
        public virtual DateTime DATE_RECEIPT { get;set; }
        public virtual string ID_EMPLOYEE { get; set; }
        public virtual decimal? AMOUNT { get; set; }
        public virtual int YEAR { get; set; }
        public virtual string ID_TYPE { get;set; }
        public virtual string Name_Employy { get;set;}
        public virtual string Name_Supplier { get; set; }
        public virtual string Name_type { get; set; }


    }
}