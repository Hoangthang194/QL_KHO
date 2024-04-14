using FluentNHibernate.Mapping;
using MWH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Mapping
{
    public class T_MD_UNIT_Map : ClassMap<T_MD_UNIT>
    {
        public T_MD_UNIT_Map()
        {
            Table("T_MD_SHIPPING_UNIT");
            Id(x => x.ID_UNIT);
            Map(x => x.NAME_UNIT);
            Map(x => x.PHONE);
            Map(x => x.IS_DELETE);
            Map(x => x.CODE);

            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}