using MWH.Core.Entities;
using MWH.Repository.Common;
using MWH.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Implement
{
    public class UnitRepo: GenericRepository<T_MD_UNIT>, IUnitRepo
    {
        public UnitRepo(NHUnitOfWork unitOfWork) : base(unitOfWork.Session)
        {

        }
    }
}