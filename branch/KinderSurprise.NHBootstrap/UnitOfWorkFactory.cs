using System;
using System.Reflection;
using FluentNHibernate;
using NHibernate;
using NHibernate.Cfg;

namespace KinderSurprise.NHBootstrap
{
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		private static ISession m_CurrentSession;
		private ISessionFactory m_SessionFactory;
		private Configuration m_Configuration;
		
		public Configuration Configuration
		{
			get
			{
				if ( m_Configuration == null )
				{
					string conn = System.Configuration.ConfigurationManager.ConnectionStrings["KinderSurpriseConnection"].ToString();
					
					m_Configuration = FluentNHibernate.Cfg.Db.MySQLConfiguration
						.Standard
                        .ConnectionString(c => c.Is(conn))
                        .ShowSql()
                        .Cache(c => c.ProviderClass(typeof(NHibernate.Cache.HashtableCacheProvider).AssemblyQualifiedName).UseQueryCache())
                        .ConfigureProperties(new NHibernate.Cfg.Configuration());
						

				    var persistenceModel = new PersistenceModel();
                    persistenceModel.AddMappingsFromAssembly(Assembly.Load("KinderSurprise.Mapper"));
                    persistenceModel.Configure(m_Configuration);
				}
				
				return m_Configuration; 
			}
		}
		
		public ISessionFactory SessionFactory
		{
			get
			{
				if (m_SessionFactory == null)
					m_SessionFactory = Configuration.BuildSessionFactory();
				return m_SessionFactory;
			}
		}
		
		public ISession CurrentSession
		{
			get
			{
				if (m_CurrentSession == null)
					throw new InvalidOperationException("You are not in a unit of work.");
				return m_CurrentSession;
			}
			set { m_CurrentSession = value; }
		}
		
		private ISession CreateSession()
		{
			return SessionFactory.OpenSession();
		}
		
		internal UnitOfWorkFactory ()
		{
		}
	
		public IUnitOfWork Create ()
		{
			ISession session = CreateSession();
			session.FlushMode = FlushMode.Commit;
			m_CurrentSession = session;
			return new UnitOfWorkImplementer(this, session);
		}
		
		public void DisposeUnitOfWork(UnitOfWorkImplementer adapter)
		{
			CurrentSession = null;
			UnitOfWork.DisposeUnitOfWork(adapter);
		}
	}
}

