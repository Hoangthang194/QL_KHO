using FluentNHibernate.Mapping;
using MWH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Mapping
{
    public class T_MD_WAREHOUSE_Map : ClassMap<T_MD_WAREHOUSE>
    {
        public T_MD_WAREHOUSE_Map()
        {
            Table("T_MD_WAREHOUSE");
            Id(x => x.ID_WAREHOUSE);
            Map(x => x.NAME_WAREHOUSE);
            Map(x => x.AREA_CODE);
            Map(x => x.IS_DELETE);
            Map(x => x.CODE);

            Map(x => x.CAPACITY).Nullable();
            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}