namespace Localwire.Graphinder.Algorithms.Service.Configuration
{
    using System;
    using Base;
    using DataAccess.EntityFramework;

    public class WorkerConfiguration : IWorkerConfiguration
    {
        private readonly DatabaseConfiguration _dbConfiguration;

        public WorkerConfiguration(DatabaseConfiguration dbConfiguration)
        {
            _dbConfiguration = dbConfiguration;
        }

        public Uri NotificationHubAddress { get; private set; }
        public TimeSpan HowOftenPersistWork { get; set; }
        public bool IsDatabaseSetUp { get; private set; }

        public void AcceptNewNotificationHub(Uri hubAddress)
        {
            throw new NotImplementedException();
        }
    }
}
