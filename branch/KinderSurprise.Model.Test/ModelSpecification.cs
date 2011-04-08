using System;
using System.Configuration;
using System.Data.Common;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using KinderSurprise.Mapper;
using KinderSurprise.RepositoryImpl;
using NHibernate.Engine;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace KinderSurprise.Model.Test
{
    [TestFixture]
    public class ModelSpecification
    {
        [Test]
		[Ignore]
        public void CanGenerateSchemaScript()
        {
			new SchemaExport(UnitOfWork.Configuration)
				.Execute(true, false, false);
        }
    }
}
