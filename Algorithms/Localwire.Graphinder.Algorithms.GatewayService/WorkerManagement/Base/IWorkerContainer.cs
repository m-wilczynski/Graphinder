namespace GatewayService.WorkerManagement.Base
{
    using System.Collections.Generic;

    public interface IWorkerContainer
    {
        ICollection<WorkerInstance> Instances { get; }

        void RegisterInstance(WorkerInstance instance);
        void UnregisterInstance(WorkerInstance instance);
    }
}
