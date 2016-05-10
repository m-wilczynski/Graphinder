namespace Localwire.Graphinder.Algorithms.WorkerApi.Controllers.WorkDelegation
{
    using Base;
    using Service.Configuration.Base;
    using Service.CurrentWork.Base;

    public class WorkerStartController : WorkerController
    {
        public WorkerStartController(IWorkerConfiguration workerConfiguration, IWorkerScheduler workerScheduler) : base(workerConfiguration, workerScheduler)
        {
        }
    }
}