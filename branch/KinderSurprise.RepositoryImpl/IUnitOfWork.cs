using System;

namespace KinderSurprise.RepositoryImpl
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericTransaction BeginTransaction();
		void TransactionalFlush();
	}
}

