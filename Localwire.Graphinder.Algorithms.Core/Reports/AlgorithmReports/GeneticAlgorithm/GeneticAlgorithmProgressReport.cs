namespace Localwire.Graphinder.Core.Reports.AlgorithmReports.GeneticAlgorithm
{
    using System;
    using System.Collections.Generic;
    using Graph;

    public class GeneticAlgorithmProgressReport : BaseEntity, IGeneticAlgorithmProgressReport
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
        /// Current generation of <see cref="T:Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.GeneticAlgorithm"/>
        /// </summary>
        public uint CurrentGeneration { get; }

        //TODO: Could use GeneticAlgorithm instance instead of lots of params
        public GeneticAlgorithmProgressReport(long processorTime, ICollection<Node> currentSolution,
            uint currentFitness, uint currentGeneration, bool accepted = false, Guid? id = null) : base(id)
        {
            if (processorTime < 0)
                throw new ArgumentOutOfRangeException(nameof(processorTime), processorTime, "Processor time is lower than 0");
            if (currentSolution == null)
                throw new ArgumentNullException(nameof(currentSolution));
            ReportDate = DateTime.Now;
            ProcessorTime = processorTime;
            CurrentSolution = currentSolution;
            CurrentFitness = currentFitness;
            CurrentGeneration = currentGeneration;
            Accepted = accepted;
        }
    }
}
