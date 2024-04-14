using FluentNHibernate.Mapping;
using MWH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Mapping
{
    public class T_MD_TYPE_Map : ClassMap<T_MD_TYPE>
    {
        public T_MD_TYPE_Map()
        {
            Table("TYPE_PRODUCT");
            Id(x => x.ID_TYPE);
            Map(x => x.NAME_TYPE);
            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
            Map(x => x.IS_DELETE);
            Map(x => x.CODE);

        }
    }
}