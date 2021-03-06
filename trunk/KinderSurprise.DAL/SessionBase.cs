using System.Configuration;
using System.Reflection;
using FluentNHibernate;
using NHibernate;

namespace KinderSurprise.DAL
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
					string conn = ConfigurationManager.ConnectionStrings["KinderSurpriseConnection"].ToString();
					
					var configuration = FluentNHibernate.Cfg.Db.MySQLConfiguration
						.Standard
                        .ConnectionString(c => c.Is(conn))
                        .ShowSql()
                        .Cache(c => c.ProviderClass(typeof(NHibernate.Cache.HashtableCacheProvider).AssemblyQualifiedName).UseQueryCache())
                        .ConfigureProperties(new NHibernate.Cfg.Configuration());
						

				    var persistenceModel = new PersistenceModel();
                    persistenceModel.AddMappingsFromAssembly(Assembly.Load("KinderSurprise.Mapper"));
                    persistenceModel.Configure(configuration);
                    m_SessionFactory = configuration.BuildSessionFactory();
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
