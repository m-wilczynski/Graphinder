namespace Localwire.Graphinder.Algorithms.Service.Configuration
{
    using System;
    using Base;
    using DataAccess.EntityFramework;
    using DTO.Administration.WorkerRegistration;

    public class WorkerConfiguration : IWorkerConfiguration
    {
        private readonly IConnectionTester _connectionTester;
        private readonly IConnectionStringBuilder _connectionBuilder;

        public WorkerConfiguration(IConnectionTester connectionTester, IConnectionStringBuilder connectionBuilder)
        {
            _connectionTester = connectionTester;
            _connectionBuilder = connectionBuilder;
        }

        public IDatabaseConfiguration Configuration { get; private set; }
        public Uri NotificationHubAddress { get; private set; }
        public TimeSpan HowOftenPersistWork { get; set; }

        public bool AcceptNewNotificationHub(Uri hubAddress)
        {
            throw new NotImplementedException();
        }

        public bool AcceptNewDatabaseConnection(GatewayRegistrationCallback registrationCallback)
        {
            if (registrationCallback == null)
                throw new ArgumentNullException(nameof(registrationCallback));
            Configuration = _connectionBuilder.BuildConnectionString(registrationCallback);
            var result = _connectionTester.CanConnectToDatabase(Configuration);
            if (!result)
                Configuration = null;
            return result;
        }
    }
}
