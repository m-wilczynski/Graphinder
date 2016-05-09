namespace Localwire.Graphinder.Algorithms.Service.Configuration
{
    using DataAccess.EntityFramework;

    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public DatabaseConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}
