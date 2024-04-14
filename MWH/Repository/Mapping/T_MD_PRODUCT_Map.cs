using FluentNHibernate.Mapping;
using MWH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Mapping
{
    public class T_MD_PRODUCT_Map : ClassMap<T_MD_PRODUCT>
    {
        public T_MD_PRODUCT_Map()
        {
            Table("T_MD_PRODUCT");
            Id(x => x.ID_PRODUCT);
            Map(x => x.NAME_PRODUCT);
            Map(x => x.NUMBER_PRODUCT);
            Map(x => x.NUMBER_PRODUCT_TODAY);
            Map(x => x.UNIT);
            Map(x => x.ID_TYPE);
            Map(x => x.IS_DELETE);
            Map(x => x.CODE);

            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}