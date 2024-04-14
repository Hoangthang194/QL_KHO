using MWH.Core.Entities;
using MWH.Core.Entities.BP;
using MWH.Repository.Common;
using MWH.Repository.Interface;
using MWH.Repository.Interface.BP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Implement.BP
{
    public class ReceiptRepo : GenericRepository<T_BP_RECEIPT>, IReceiptRepo
    {
        public ReceiptRepo(NHUnitOfWork unitOfWork) : base(unitOfWork.Session)
        {

        }
    }
}