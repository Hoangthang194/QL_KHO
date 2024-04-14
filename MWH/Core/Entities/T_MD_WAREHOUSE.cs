using MWH.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Core.Entities
{
    public partial class T_MD_WAREHOUSE : BaseEntity
    {
        public virtual string ID_WAREHOUSE { get; set; }
        public virtual string NAME_WAREHOUSE { get; set; }
        public virtual string AREA_CODE { get; set; }
        public virtual string CAPACITY { get; set; }

    }
}