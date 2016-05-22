namespace Localwire.Graphinder.Algorithms.WorkerApi.Controllers.Configuration
{
    using System;
    using System.Web.Http;
    using Base;
    using Core.Algorithms;
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
            var current = WorkerScheduler.CurrentlyWorked as Algorithm;
            return new WorkerStatusResponse
            {
                CurrentlyWorkedAlgorithmInstance = current == null ? (Guid?)null : current.Id,
                IsBusy = !WorkerScheduler.CanAcceptWork()
            };
        }
    }
}