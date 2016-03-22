namespace Localwire.Graphinder.Core.Report
{
    using System;
    using System.Collections.Generic;
    using Graph;

    public interface IAlgorithmProgressReport
    {
        DateTime ReportDate { get; }
        long ProcessorTime { get; }
        ICollection<Node> CurrentSolution { get; }
        uint CurrentFitness { get; } 
    }
}
