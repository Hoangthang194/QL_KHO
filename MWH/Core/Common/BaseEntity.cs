using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Core.Common
{
    public partial class BaseEntity
    {
        public virtual string CREATE_BY { get; set; }
        public virtual DateTime? CREATE_DATE { get; set; }
        public virtual string UPDATE_BY { get; set; }
        public virtual DateTime? UPDATE_DATE { get; set; }
        public virtual bool IS_DELETE { get; set; }
        public virtual string CODE { get; set; }

    }
}