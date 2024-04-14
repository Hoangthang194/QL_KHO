using FluentNHibernate.Mapping;
using MWH.Core.Entities.BP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Mapping.BP
{
    public class T_BP_RECEIPT_DETAIL_Map : ClassMap<T_BP_RECEIPT_DETAIL>
    {
        public T_BP_RECEIPT_DETAIL_Map()
        {
            Table("T_BP_RECEIPT_DETAIL");
            Map(x => x.ID_RECEIPT);
            Id(x => x.ID_PRODUCT);
            Map(x => x.PRICE_RECEIPT);
            Map(x => x.NUMBER_RECEIPT);
            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}