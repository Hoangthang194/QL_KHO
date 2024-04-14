using FluentNHibernate.Mapping;
using MWH.Core.Entities.BP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Mapping.BP
{
    public class T_BP_DELIVERY_DETAIL_Map : ClassMap<T_BP_DELIVERY_DETAIL>
    {
        public T_BP_DELIVERY_DETAIL_Map()
        {
            Table("T_BP_DELIVERY_DETAIL");
            Map(x => x.ID_DELIVERY);
            Id(x => x.ID_PRODUCT);
            Map(x => x.PRICE_DELIVERY);
            Map(x => x.NUMBER_DELIVERY);
            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}