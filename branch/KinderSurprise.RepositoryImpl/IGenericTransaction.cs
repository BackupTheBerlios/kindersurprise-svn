using System;
namespace KinderSurprise.RepositoryImpl
{
	public interface IGenericTransaction : IDisposable
	{
		void Commit();
		void Rollback();
	}
}

