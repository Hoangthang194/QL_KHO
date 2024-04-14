using MWH.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Core.Entities
{
    public class T_MD_TYPE : BaseEntity
    {
        public virtual string ID_TYPE { get; set; }
        public virtual string NAME_TYPE { get; set; }

    }
}