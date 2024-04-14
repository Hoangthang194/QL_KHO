using FluentNHibernate.Mapping;
using MWH.Core.Entities;
using MWH.Core.Entities.BP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Mapping.BP
{
    public class T_BP_RECEIPT_Map : ClassMap<T_BP_RECEIPT>
    {
        public T_BP_RECEIPT_Map()
        {
            Table("T_BP_RECEIPT");
            Map(x => x.ID_SUPPLIER);
            Id(x => x.ID_RECEIPT);
            Map(x => x.DATE_RECEIPT);
            Map(x => x.AMOUNT);
            Map(x => x.ID_EMPLOYEE);
            Map(x => x.YEAR);
            Map(x => x.ID_TYPE);
            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}