using MWH.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Core.Entities
{
    public class T_MD_UNIT : BaseEntity
    {
        public virtual string ID_UNIT { get; set; }
        public virtual string NAME_UNIT { get; set; }

        public virtual string PHONE { get; set; }

    }
}