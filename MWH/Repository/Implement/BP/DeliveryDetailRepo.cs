using MWH.Core.Entities.BP;
using MWH.Repository.Common;
using MWH.Repository.Interface.BP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Implement.BP
{
    public class DeliveryDetailRepo : GenericRepository<T_BP_DELIVERY_DETAIL>, IDeliverytDetailRepo
    {
        public DeliveryDetailRepo(NHUnitOfWork unitOfWork) : base(unitOfWork.Session)
        {

        }
    }
}