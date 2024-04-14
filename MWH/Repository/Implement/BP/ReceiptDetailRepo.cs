using MWH.Core.Entities.BP;
using MWH.Repository.Common;
using MWH.Repository.Interface.BP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Implement.BP
{
    public class ReceiptDetailRepo : GenericRepository<T_BP_RECEIPT_DETAIL>, IReceiptDetailRepo
    {
        public ReceiptDetailRepo(NHUnitOfWork unitOfWork) : base(unitOfWork.Session)
        {

        }
    }
}