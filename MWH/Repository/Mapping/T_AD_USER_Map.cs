using FluentNHibernate.Mapping;
using MWH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Mapping
{
    public class T_AD_USER_Map : ClassMap<T_AD_USER>
    {
        public T_AD_USER_Map()
        {
            Table("T_AD_USER");
            Id(x => x.CODE);
            Map(x => x.USER_NAME);
            Map(x => x.ORG_CODE);
            Map(x => x.PASSWORD).Not.Nullable();
            Map(x => x.EMAIL);
            Map(x => x.PHONE);
            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}