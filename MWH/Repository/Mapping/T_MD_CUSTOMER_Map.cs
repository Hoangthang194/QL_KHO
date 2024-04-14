using FluentNHibernate.Mapping;
using MWH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Mapping
{
    public class T_MD_CUSTOMER_Map : ClassMap<T_MD_CUSTOMER>
    {
        public T_MD_CUSTOMER_Map()
        {
            Table("T_MD_CUSTOMER");
            Id(x => x.ID_CUSTOMER);
            Map(x => x.NAME_CUSTOMER);
            Map(x => x.ADDRESS_CUSTOMER);
            Map(x => x.PHONE_CUSTOMER);
            Map(x => x.IS_DELETE);
            Map(x => x.CODE);

            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}