using MWH.Core.Entities;
using MWH.Repository.Implement;
using MWH.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Service.AD
{
    public class UserService : GenericService<T_AD_USER, UserRepo>
    {
        public void Create(string email, string password)
        {
            UnitOfWork.BeginTransaction();
            var user = new T_AD_USER()
            {
                CODE = Guid.NewGuid().ToString(),
                EMAIL = email,
                PASSWORD = password,
                USER_NAME = email
            };
            UnitOfWork.Repository<UserRepo>().Create(user);
            UnitOfWork.Commit();
            
        }
    }
}