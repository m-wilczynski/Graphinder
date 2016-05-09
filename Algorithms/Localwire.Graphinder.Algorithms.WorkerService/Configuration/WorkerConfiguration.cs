namespace Localwire.Graphinder.Algorithms.Service.Configuration
{
    using System;
    using Base;
    using DataAccess.EntityFramework;

    public class WorkerConfiguration : IWorkerConfiguration
    {
        public IDatabaseConfiguration Configuration { get; private set; }
        public Uri NotificationHubAddress { get; private set; }
        public TimeSpan HowOftenPersistWork { get; set; }
        public bool IsDatabaseSetUp { get; private set; }

        public void AcceptNewNotificationHub(Uri hubAddress)
        {
            throw new NotImplementedException();
        }

        public void AcceptNewDatabaseConnection(IDatabaseConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}
