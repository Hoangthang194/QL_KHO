using MWH.Core.Entities;
using MWH.Repository.Common;
using MWH.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Implement
{
    public class ProductRepo : GenericRepository<T_MD_PRODUCT>, IProductRepo
    {
        public ProductRepo(NHUnitOfWork unitOfWork) : base(unitOfWork.Session)
        {

        }
    }
}