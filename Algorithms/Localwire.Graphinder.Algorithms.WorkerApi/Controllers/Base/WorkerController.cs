using System.Web.Http;

namespace Localwire.Graphinder.Algorithms.WorkerApi.Controllers.Base
{
    using Service.Configuration.Base;
    using Service.CurrentWork.Base;

    public abstract class WorkerController : ApiController
    {
        protected readonly IWorkerConfiguration WorkerConfiguration;
        protected readonly IWorkerScheduler WorkerScheduler;

        protected WorkerController(IWorkerConfiguration workerConfiguration, IWorkerScheduler workerScheduler)
        {
            WorkerConfiguration = workerConfiguration;
            WorkerScheduler = workerScheduler;
        }
    }
}