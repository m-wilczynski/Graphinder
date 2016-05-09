namespace Localwire.Graphinder.Algorithms.Service.Configuration.Base
{
    using System;
    using DataAccess.EntityFramework;

    public interface IWorkerConfiguration
    {
        IDatabaseConfiguration Configuration { get; }
        Uri NotificationHubAddress { get; }
        TimeSpan HowOftenPersistWork { get; }
        bool IsDatabaseSetUp { get; }

        void AcceptNewNotificationHub(Uri hubAddress);
        void AcceptNewDatabaseConnection(IDatabaseConfiguration configuration);
    }
}
