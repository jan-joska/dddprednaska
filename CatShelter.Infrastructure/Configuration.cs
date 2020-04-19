using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace CatShelter.Infrastructure
{
    public class Configuration
    {

        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Server=JJ-HQ-DESKTOP\SQLEXPRESS;Database=DDDSamples;Trusted_Connection=True;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Configuration>())
                .BuildSessionFactory();
        }

    }
}