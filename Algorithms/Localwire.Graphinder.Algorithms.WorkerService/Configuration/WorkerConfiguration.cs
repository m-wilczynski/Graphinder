namespace Localwire.Graphinder.Algorithms.Service.Configuration
{
    using System;
    using Base;

    public class WorkerConfiguration : IWorkerConfiguration
    {
        public Uri NotificationHubAddress { get; private set; }
        public TimeSpan HowOftenPersistWork { get; set; }

        public void AcceptNewNotificationHub(Uri hubAddress)
        {
            throw new NotImplementedException();
        }
    }
}
