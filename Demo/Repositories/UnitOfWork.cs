using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Demo.Mapping;

namespace Demo.Repositories
{
    class UnitOfWork
    {
        private const string serverName = @"home-pc";
        private const string databaseName = "Demo";
        private static string connectString = string.Format("server={0};database={1};Integrated Security=SSPI;", serverName, databaseName);

        private static Configuration configuration = null;
        private static ISessionFactory sessionFactory = null;

        public static Configuration GetConfiguration()
        {
            if (configuration == null)
            {
                configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectString))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Program>()
                .Conventions.Add<MyForeignKeyConvention>())
                .BuildConfiguration();
            }
            return configuration;
        }

        public static ISessionFactory GetSessionFactory()
        {
            if (configuration == null)
                configuration = GetConfiguration();

            if (sessionFactory == null)
                sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory;
        }               
    }
}
