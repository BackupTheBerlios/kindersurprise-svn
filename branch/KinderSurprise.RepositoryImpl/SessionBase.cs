using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using KinderSurprise.Mapper;
using NHibernate;
using NHibernate.Cache;
using System.Reflection;

namespace KinderSurprise.RepositoryImpl
{
	public static class SessionBase
	{
        public static NHibernate.Cfg.Configuration GetConfiguration()
        {
            string conn = ConfigurationManager.AppSettings["KinderSurpriseConnection"];

            var config = Fluently.Configure()
                .Database(MySQLConfiguration
                              .Standard
                              .ConnectionString(c => c.Is(conn))
				          	  .ShowSql()
                              .Cache(
                                  c =>
                                  c.ProviderClass(typeof (HashtableCacheProvider).AssemblyQualifiedName).UseQueryCache()))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoryMap>());
					
            return config.BuildConfiguration();
        }

		private static ISessionFactory m_SessionFactory;

		private static ISessionFactory SessionFactory
		{
            get { return m_SessionFactory ?? (m_SessionFactory = GetConfiguration().BuildSessionFactory()); }
		}

		public static ISession OpenSession()
		{
			return SessionFactory.OpenSession();
		}
	}
}
