using System;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace CatShelter.Application
{
    public class UnitOfWork2 : IDisposable
    {

        private static readonly Lazy<ISessionFactory> SessionFactory = new Lazy<ISessionFactory>(() =>
        {
            return Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Server=JJ-HQ-DESKTOP\SQLEXPRESS;Database=DDDSamples;Trusted_Connection=True;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Configuration>())
                .BuildSessionFactory();
        });

        private ISession _session;

        public UnitOfWork2()
        {
            _session = SessionFactory.Value.OpenSession();
        }

        public ISession Session => _session;

        public async Task Complete()
        {
            await _session.FlushAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            _session?.Dispose();
        }
    }
}