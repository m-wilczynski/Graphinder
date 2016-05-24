namespace GatewayService.WorkerManagement
{
    using System;
    using System.Reactive.Linq;
    using System.Threading;
    using Base;

    public class WorkerHeartbeat
    {
        public const int MinimalIntervalInSeconds = 5;
        private readonly IWorkerContainer _container;
        private readonly TimeSpan _heartbeatInterval;
        private bool _isRunning;

        public WorkerHeartbeat(IWorkerContainer container, TimeSpan heartbeatInterval)
        {
            _container = container;
            if (_heartbeatInterval.TotalSeconds < MinimalIntervalInSeconds)
                throw new InvalidOperationException($"Cannot heartbeat often than {MinimalIntervalInSeconds}");
            _heartbeatInterval = heartbeatInterval;
            StartHeartbeat();
        }

        public bool RestartHeartbeat()
        {
            if (_isRunning) return false;
            StartHeartbeat();
            return true;
        }

        private void StartHeartbeat()
        {
            if (_isRunning) return;
            try
            {
                _isRunning = true;
                Observable.Interval(_heartbeatInterval).Subscribe(_ =>
                {
                    foreach (var instance in _container.Instances)
                    {
                        var checkerThread = new Thread(() => CheckInstance(instance));
                        checkerThread.Start();
                    }
                });
            }
            finally
            {
                _isRunning = false;
            }
        }

        private void CheckInstance(WorkerInstance instance)
        {
            //TODO: Check if alive
        }
    }
}
