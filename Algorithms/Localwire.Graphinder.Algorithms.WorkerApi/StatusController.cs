using System.Web.Http;

namespace Localwire.Graphinder.Algorithms.WorkerApi
{
    using Controllers.Base;
    using Service.Configuration.Base;
    using Service.CurrentWork.Base;

    [RoutePrefix("api/status")]
    public class StatusController : WorkerController
    {

        public StatusController(IWorkerConfiguration workerConfiguration, IWorkerScheduler workerScheduler) : base(workerConfiguration, workerScheduler)
        {
        }

        [Route]
        public string IsWorkerBusy()
        {
            return "value";
        }
    }
}