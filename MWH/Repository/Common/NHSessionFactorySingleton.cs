using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping.Providers;
using MWH.Repository.Mapping;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MWH.Repository.Common
{
    public static class NHSessionFactorySingleton
    {
        private static ISessionFactory _sessionFactory = null;
        private static readonly object _lockObj = new object();

        public static ISessionFactory SessionFactory
        {
            get
            {
                lock (_lockObj)
                {
                    if (_sessionFactory == null)
                    {
                        try
                        {
                            string strConnection = ConfigurationManager.ConnectionStrings["MAN_Connection"].ConnectionString;
                            FluentConfiguration _configuration = Fluently.Configure()
                                .Database(MsSqlConfiguration.MsSql2008
                                .ConnectionString(strConnection).DoNot.ShowSql())
                                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<T_AD_USER_Map>(t => t.Namespace.StartsWith("MWH.Repository.Mapping")));

                            _sessionFactory = _configuration.BuildSessionFactory();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                return _sessionFactory;
            }
        }

        public static FluentMappingsContainer AddFromAssemblyOf<T>(
    this FluentMappingsContainer mappings,
    Predicate<Type> where)
        {
            if (where == null)
                return mappings.AddFromAssemblyOf<T>();

            var mappingClasses = typeof(T).Assembly.GetExportedTypes()
                .Where(x => (typeof(IMappingProvider).IsAssignableFrom(x)
                        || typeof(IExternalComponentMappingProvider).IsAssignableFrom(x))
                    && where(x));

            foreach (var type in mappingClasses)
            {
                mappings.Add(type);
            }

            return mappings;
        }

        public static ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}