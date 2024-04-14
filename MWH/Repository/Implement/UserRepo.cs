using MWH.Core.Entities;
using MWH.Repository.Common;
using MWH.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Implement
{
    public class UserRepo : GenericRepository<T_AD_USER>, IUserRepo
    {
        public UserRepo(NHUnitOfWork unitOfWork) : base(unitOfWork.Session)
        {

        }
    }
}