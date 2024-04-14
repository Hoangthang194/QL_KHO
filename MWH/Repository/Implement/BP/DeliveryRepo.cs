using MWH.Core.Entities.BP;
using MWH.Repository.Common;
using MWH.Repository.Interface.BP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Implement.BP
{
    public class DeliveryRepo : GenericRepository<T_BP_DELIVERY>, IDeliveryRepo
    {
        public DeliveryRepo(NHUnitOfWork unitOfWork) : base(unitOfWork.Session)
        {

        }
    }
}