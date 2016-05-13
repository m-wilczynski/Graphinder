using System.Collections.Generic;
using System.Web.Http;

namespace Localwire.Graphinder.Algorithms.WorkerApi.Controllers.Configuration
{
    using System;
    using Base;
    using DTO.Administration.WorkerRegistration;
    using Service.Configuration.Base;
    using Service.CurrentWork.Base;

    [RoutePrefix("api/serviceregistration")]
    public class WorkerRegistrationController : WorkerController
    {
        public WorkerRegistrationController(IWorkerConfiguration workerConfiguration, IWorkerScheduler workerScheduler) : base(workerConfiguration, workerScheduler)
        {
        }

        public WorkerRegistrationFinalization Post([FromBody]GatewayRegistrationCallback registrationCallback)
        {
            if (registrationCallback == null)
                throw new ArgumentNullException(nameof(registrationCallback));

            bool success = false;
            Exception exception = null;
            try
            {
                success = WorkerConfiguration.AcceptNewDatabaseConnection(registrationCallback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            return new WorkerRegistrationFinalization
            {
                HasSuccessfullyConnectedToDatabase = success,
                ConnectionException = exception
            };
        }
    }
}