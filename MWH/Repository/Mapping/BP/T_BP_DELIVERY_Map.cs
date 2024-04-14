using FluentNHibernate.Mapping;
using MWH.Core.Entities.BP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Mapping.BP
{
    public class T_BP_DELIVERY_Map : ClassMap<T_BP_DELIVERY>
    {
        public T_BP_DELIVERY_Map()
        {
            Table("T_BP_DELIVERY");
            Map(x => x.ID_CUSTOMER);
            Id(x => x.ID_DELIVERY);
            Map(x => x.DATE_DELIVERY);
            Map(x => x.AMOUNT);
            Map(x => x.ID_EMPLOYEE);
            Map(x => x.YEAR);
            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}