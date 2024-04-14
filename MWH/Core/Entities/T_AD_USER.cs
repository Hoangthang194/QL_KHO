using MWH.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Core.Entities
{
    public partial class T_AD_USER : BaseEntity
    {

        public virtual string USER_NAME { get; set; }
        public virtual string PASSWORD { get; set; }
        public virtual string ORG_CODE { get; set; }
        public virtual string EMAIL { get; set; }
        public virtual string PHONE { get; set; }
    }
}