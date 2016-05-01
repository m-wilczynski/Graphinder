namespace Localwire.Graphinder.Algorithms.Service.Base
{
    using Core.Algorithms;

    interface IAlgorithmWorker
    {
        IAlgorithm CurrentlyWorkedAlgorithm { get; }
        bool CanAcceptAlgorithm();
    }
}
