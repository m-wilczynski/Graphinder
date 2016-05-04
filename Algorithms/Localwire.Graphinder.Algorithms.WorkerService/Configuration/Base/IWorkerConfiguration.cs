namespace Localwire.Graphinder.Algorithms.Service.Configuration.Base
{
    using System;

    public interface IWorkerConfiguration
    {
        Uri NotificationHubAddress { get; }
        TimeSpan HowOftenPersistWork { get; }

        void AcceptNewNotificationHub(Uri hubAddress);
    }
}
