using FluentNHibernate.Mapping;
using MWH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Mapping
{
    public class T_ORG_Map: ClassMap<T_AD_ORG>
    {
        public T_ORG_Map()
        {
            Table("T_AD_OGN");
            Id(x => x.CODE);
            Map(x => x.PARENT_CODE);
            Map(x => x.AREA_CODE);
            Map(x => x.ISGROUP);
            Map(x => x.NAME);

            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}