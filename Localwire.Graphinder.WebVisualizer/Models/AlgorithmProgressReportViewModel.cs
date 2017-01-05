namespace Localwire.Graphinder.WebVisualizer.Models
{
    using System;
    using System.Collections.Generic;

    public class AlgorithmProgressReportViewModel
    {
        public DateTime ReportDate { get; set; }
        public long ProcessorTime { get; set; }
        public ICollection<GraphNodeViewModel> CurrentSolution { get; set; }
        public uint CurrentFitness { get; set; }
        public bool Accepted { get; set; }
    }
}