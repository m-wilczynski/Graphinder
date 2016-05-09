namespace Localwire.Graphinder.Algorithms.Service.CurrentWork.Base
{
    using Core.Algorithms;
    using Core.Reports;

    public interface IWorkerScheduler
    {
        IAlgorithm CurrentlyWorked { get; }

        bool CanAcceptWork();
        bool SetCurrentWork(IAlgorithm algorithm);
        void PersistCurrentWork();
        void OnProgressReported(IAlgorithmProgressReport report);
    }
}
