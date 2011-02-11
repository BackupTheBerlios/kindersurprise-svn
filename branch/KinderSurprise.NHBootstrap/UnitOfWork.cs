using System;
using NHibernate;
using NHibernate.Cfg;

namespace KinderSurprise.NHBootstrap
{
	public static class UnitOfWork
	{
		private static IUnitOfWorkFactory m_UnitOfWorkFactory = new UnitOfWorkFactory();
		private static IUnitOfWork m_InnerUnitOfWork;
		
		public static IUnitOfWork Current
		{
			get
			{
				if (m_InnerUnitOfWork == null)
					throw new InvalidOperationException("You are not in a unit of work");
				return m_InnerUnitOfWork;
			}
		}
		
		public static bool IsStarted
		{
			get { return m_InnerUnitOfWork != null; }
		}
		
		public static ISession CurrentSession
		{
			get { return m_UnitOfWorkFactory.CurrentSession; }
   			internal set { m_UnitOfWorkFactory.CurrentSession = value; }
		}

		public static Configuration Configuration
		{
			get { return m_UnitOfWorkFactory.Configuration; }
		}
		
		public static IUnitOfWork Start()
		{
			if ( m_InnerUnitOfWork != null )
				throw new InvalidOperationException("You cannot start more than one unit of work at the same time");
			
			m_InnerUnitOfWork = m_UnitOfWorkFactory.Create();
			return m_InnerUnitOfWork;
		}
		
		public static void DisposeUnitOfWork(UnitOfWorkImplementer unitOfWork)
		{
			m_InnerUnitOfWork = null;
		}
	}
}

