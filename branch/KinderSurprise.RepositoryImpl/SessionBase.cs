using System.Configuration;
using System.Reflection;
using FluentNHibernate;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cache;

namespace KinderSurprise.RepositoryImpl
{
	public static class SessionBase
	{
		private static ISessionFactory m_SessionFactory;

		private static ISessionFactory SessionFactory
		{
			get 
			{
				if (m_SessionFactory == null)
				{
					string conn = ConfigurationManager.AppSettings["KinderSurpriseConnection"];

                    var configuration =
                        MySQLConfiguration
                        .Standard
                        .ConnectionString(c => c.Is(conn))
                        .ShowSql()
                        .Cache(c => c.ProviderClass(typeof(HashtableCacheProvider).AssemblyQualifiedName).UseQueryCache())
                        .ConfigureProperties(new NHibernate.Cfg.Configuration());


                    var persistenceModel = new PersistenceModel();
                    persistenceModel.AddMappingsFromAssembly(Assembly.Load("KinderSurprise.Mapper"));
                    persistenceModel.Configure(configuration);
                    m_SessionFactory = configuration.BuildSessionFactory();
                    //m_SessionFactory = Fluently.Configure().Database(
                    //    MySQLConfiguration
                    //        .Standard
                    //        .ConnectionString(c => c.Is(conn))
                    //        .ShowSql()
                    //        .Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>()))
                    //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoryMap>())
                    //    .BuildSessionFactory();
				}
				return m_SessionFactory;
			}
		}

		public static ISession OpenSession()
		{
			return SessionFactory.OpenSession();
		}
	}
}
