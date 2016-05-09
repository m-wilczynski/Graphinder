namespace Localwire.Graphinder.Algorithms.Service.Configuration.Base
{
    using DataAccess.EntityFramework;
    using DTO.Administration.WorkerRegistration;

    interface IConnectionStringBuilder
    {
        IDatabaseConfiguration BuildConnectionString(GatewayRegistrationCallback registrationCallback);
    }
}
