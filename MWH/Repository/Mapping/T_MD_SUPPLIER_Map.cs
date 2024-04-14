using FluentNHibernate.Mapping;
using MWH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Mapping
{
    public class T_MD_SUPPLIER_Map : ClassMap<T_MD_SUPPLIER>
    {
        public T_MD_SUPPLIER_Map()
        {
            Table("T_MD_SUPPLIER");
            Id(x => x.ID_SUPPLIER);
            Map(x => x.NAME_SUPPLIER);
            Map(x => x.ADDRESS_SUPPLIER);
            Map(x => x.EMAIL_SUPPLIER);
            Map(x => x.PHONE_SUPPLIER);
            Map(x => x.IS_DELETE);
            Map(x => x.CODE);


            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}