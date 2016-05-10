namespace Localwire.Graphinder.Algorithms.Service.Configuration.Base
{
    using System;
    using DataAccess.EntityFramework;
    using DTO.Administration.WorkerRegistration;

    public interface IWorkerConfiguration
    {
        IDatabaseConfiguration Configuration { get; }
        Uri NotificationHubAddress { get; }
        TimeSpan HowOftenPersistWork { get; }

        bool AcceptNewNotificationHub(Uri hubAddress);
        bool AcceptNewDatabaseConnection(GatewayRegistrationCallback registrationCallback);
    }
}
