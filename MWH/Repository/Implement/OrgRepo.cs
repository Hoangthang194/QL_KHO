using MWH.Core.Entities;
using MWH.Repository.Common;
using MWH.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Implement
{
    public class OrgRepo : GenericRepository<T_AD_ORG>, IOrgRepo
    {
        public OrgRepo(NHUnitOfWork unitOfWork) : base(unitOfWork.Session)
        {

        }
    }
}