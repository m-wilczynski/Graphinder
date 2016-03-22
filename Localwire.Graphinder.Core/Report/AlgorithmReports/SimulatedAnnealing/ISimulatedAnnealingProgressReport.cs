namespace Localwire.Graphinder.Core.Report.AlgorithmReports.SimulatedAnnealing
{
    public interface ISimulatedAnnealingProgressReport : IAlgorithmProgressReport
    {
        double CurrentTemperature { get; }
    }
}
