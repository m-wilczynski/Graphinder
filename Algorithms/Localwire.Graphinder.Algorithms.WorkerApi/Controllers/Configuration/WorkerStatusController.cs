using System.Collections.Generic;
using System.Web.Http;

namespace Localwire.Graphinder.Algorithms.WorkerApi.Controllers.Configuration
{
    using Base;
    using DTO.Administration.WorkerJobDelegation;
    using Service.Configuration.Base;
    using Service.CurrentWork.Base;

    [RoutePrefix("api/status")]
    public class WorkerStatusController : WorkerController
    {
        public WorkerStatusController(IWorkerConfiguration workerConfiguration, IWorkerScheduler workerScheduler) : base(workerConfiguration, workerScheduler)
        {
        }

        [Route("")]
        [HttpGet]
        public WorkerStatusResponse GetWorkerStatus()
        {
            return null;
        }
    }
}