using System;
using NHibernate;

namespace KinderSurprise.RepositoryImpl
{
	public class UnitOfWorkImplementer : IUnitOfWork
	{
		private readonly IUnitOfWorkFactory m_Factory;
		private readonly ISession m_Session;
		
		public UnitOfWorkImplementer (IUnitOfWorkFactory factory, ISession session)
		{
			m_Factory = factory;
			m_Session = session;
		}
		
		public void Dispose()
		{
			m_Factory.DisposeUnitOfWork(this);
			m_Session.Dispose();
		}
		
		public IGenericTransaction BeginTransaction()
		{
			return new GenericTransaction(m_Session.BeginTransaction());
		}
		
		public void TransactionalFlush()
		{
			IGenericTransaction tx = BeginTransaction();
			try
			{
				tx.Commit();
			}
			catch
			{
				tx.Rollback();
				throw;
			}
			finally
			{
				tx.Dispose();
			}
		}
	}
}

