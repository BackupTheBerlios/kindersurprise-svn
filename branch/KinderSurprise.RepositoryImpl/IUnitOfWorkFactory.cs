using System;
using System.Reflection;
using FluentNHibernate;
using NHibernate;
using NHibernate.Cfg;

namespace KinderSurprise.RepositoryImpl
{
	public interface IUnitOfWorkFactory
	{
		Configuration Configuration { get; }
        ISessionFactory SessionFactory { get; }
        ISession CurrentSession { get; set; }

		IUnitOfWork Create();
		void DisposeUnitOfWork(UnitOfWorkImplementer adapter);
	}
}

