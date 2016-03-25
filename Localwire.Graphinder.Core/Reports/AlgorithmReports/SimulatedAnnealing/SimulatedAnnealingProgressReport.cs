namespace Localwire.Graphinder.Core.Reports.AlgorithmReports.SimulatedAnnealing
{
    using System;
    using System.Collections.Generic;
    using Graph;

    public class SimulatedAnnealingProgressReport : ISimulatedAnnealingProgressReport
    {
        /// <summary>
        /// Date on which report was generated
        /// </summary>
        public DateTime ReportDate { get; }

        /// <summary>
        /// Process time used up so far by algorithm
        /// </summary>
        public long ProcessorTime { get; }

        /// <summary>
        /// Current solution produced by algorithm
        /// </summary>
        public ICollection<Node> CurrentSolution { get; }

        /// <summary>
        /// Fitness of current solution
        /// </summary>
        public uint CurrentFitness { get; }

        /// <summary>
        /// Was solution accepted?
        /// </summary>
        public bool Accepted { get; }

        /// <summary>
        /// Current temperature of <see cref="T:Localwire.Graphinder.Core.Algorithms.SimulatedAnnealing.SimulatedAnnealing"/> algorithm
        /// </summary>
        public double CurrentTemperature { get; }

        public SimulatedAnnealingProgressReport(long processorTime, ICollection<Node> currentSolution,
            uint currentFitness, uint currentTemperature, bool accepted = false)
        {
            if (processorTime < 0)
                throw new ArgumentOutOfRangeException(nameof(processorTime), processorTime, "Processor time is lower than 0");
            if (currentSolution == null)
                throw new ArgumentNullException(nameof(currentSolution));
            ReportDate = DateTime.Now;
            ProcessorTime = processorTime;
            CurrentSolution = currentSolution;
            CurrentFitness = currentFitness;
            CurrentTemperature = currentTemperature;
            Accepted = accepted;
        }
    }
}
