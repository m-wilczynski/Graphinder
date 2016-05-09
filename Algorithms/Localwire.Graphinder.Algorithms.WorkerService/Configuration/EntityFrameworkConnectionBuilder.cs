namespace Localwire.Graphinder.Algorithms.Service.Configuration
{
    using Base;
    using DataAccess.EntityFramework;
    using DTO.Administration.WorkerRegistration;

    public class EntityFrameworkConnectionBuilder : IConnectionStringBuilder
    {
        public IDatabaseConfiguration BuildConnectionString(GatewayRegistrationCallback registrationCallback)
        {
            string connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder

            {
                Metadata = "res://*",
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = new System.Data.SqlClient.SqlConnectionStringBuilder
                {
                    DataSource = registrationCallback.DatabaseAddress.AbsoluteUri,
                    InitialCatalog = registrationCallback.InitialCatalog,
                    IntegratedSecurity = false,
                    UserID = registrationCallback.Username,
                    Password = registrationCallback.Password
                }.ConnectionString
            }.ConnectionString;

            return new DatabaseConfiguration(connectionString);
        }
    }
}
