using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using KinderSurprise.Mapper;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace KinderSurprise.Model.Test
{
    [TestFixture]
    public class ModelSpecification
    {
        private const string Filename = "mysqldatabasestructure.db";
        [Test, Ignore]
        public void CanGenerateSchema()
        {
            string conn = ConfigurationManager.ConnectionStrings["KinderSurpriseConnection"].ToString();

            var configuration = Fluently.Configure().Database(
                MySQLConfiguration
                    .Standard
                    .ConnectionString(c => c.Is(conn))
                    .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoryMap>())
                .BuildConfiguration();
            
            BuildSchema(configuration);
        }

        private void BuildSchema(NHibernate.Cfg.Configuration cfg)
        {
            new SchemaExport(cfg).SetOutputFile(Filename).Create(false, true);
        }
    }
}
