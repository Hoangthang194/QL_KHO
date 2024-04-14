using FluentNHibernate.Mapping;
using MWH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWH.Repository.Mapping
{
    public class T_MD_EMPLOYEE_Map : ClassMap<T_MD_EMPLOYEE>
    {
        public T_MD_EMPLOYEE_Map()
        {
            Table("T_MD_EMPLOYEE");
            Id(x => x.ID_EMPLOYEE);
            Map(x => x.NAME_EMPLOYEE);
            Map(x => x.PHONE_EMPLOYEE);
            Map(x => x.EMAIL);
            Map(x => x.IS_DELETE);
            Map(x => x.CODE);

            Map(x => x.ID_WAREHOUSE);
            Map(m => m.CREATE_BY).Not.Update();
            Map(m => m.CREATE_DATE).Generated.Insert().Not.Update();
            Map(m => m.UPDATE_BY).Not.Insert();
            Map(m => m.UPDATE_DATE).Not.Insert();
        }
    }
}