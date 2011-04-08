using NHibernate;

namespace KinderSurprise.RepositoryImpl
{
	public class GenericTransaction : IGenericTransaction
	{
		private readonly ITransaction m_Transaction;
		
		public GenericTransaction (ITransaction transaction)
		{
			m_Transaction = transaction;
		}
	
		public void Commit ()
		{
			m_Transaction.Commit();
		}

		public void Rollback ()
		{
			m_Transaction.Rollback();
		}
		
		public void Dispose ()
		{
			m_Transaction.Dispose();
		}
	}
}

