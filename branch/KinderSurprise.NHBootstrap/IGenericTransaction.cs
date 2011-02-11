using System;
namespace KinderSurprise.NHBootstrap
{
	public interface IGenericTransaction : IDisposable
	{
		void Commit();
		void Rollback();
	}
}

