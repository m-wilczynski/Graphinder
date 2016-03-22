namespace Localwire.Graphinder.Core.Report.AlgorithmReports.GeneticAlgorithm
{
    public interface IGeneticAlgorithmProgressReport : IAlgorithmProgressReport
    {
        /// <summary>
        /// Current generation of <see cref="T:Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.GeneticAlgorithm"/>
        /// </summary>
        uint CurrentGeneration { get; }
    }
}
