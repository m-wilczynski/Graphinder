namespace Localwire.Graphinder.Core.Report.AlgorithmReports.GeneticAlgorithm
{
    public interface IGeneticAlgorithmProgressReport : IAlgorithmProgressReport
    {
        uint CurrentGeneration { get; }
    }
}
