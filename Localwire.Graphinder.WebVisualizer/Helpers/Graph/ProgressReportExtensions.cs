namespace Localwire.Graphinder.WebVisualizer.Helpers.Graph
{
    using System.Linq;
    using Core.Reports;
    using Models;

    public static class ProgressReportExtensions
    {
        public static AlgorithmProgressReportViewModel AsReportViewModel(this IAlgorithmProgressReport report)
        {
            return new AlgorithmProgressReportViewModel
            {
                ReportDate = report.ReportDate,
                Accepted = report.Accepted,
                CurrentFitness = report.CurrentFitness,
                ProcessorTime = report.ProcessorTime,
                CurrentSolution = report.CurrentSolution.Select(n => 
                    new GraphNodeViewModel
                    {
                        Key = n.Key,
                        Neighbours = n.Neighbours.Select(ngh => ngh.Key).ToList()
                    }).ToList()
            };
        }
    }
}