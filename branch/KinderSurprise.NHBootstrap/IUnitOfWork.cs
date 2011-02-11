using System;

namespace KinderSurprise.NHBootstrap
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericTransaction BeginTransaction();
		void TransactionalFlush();
	}
}

