namespace Localwire.Graphinder.Core.Algorithms.SimulatedAnnealing
{
    using System;
    using System.Collections.Generic;
    using CoolingStrategies;
    using Graph;
    using Problems;
    using Reports;
    using Reports.AlgorithmReports.SimulatedAnnealing;
    using Setup;

    /// <summary>
    /// Represents simulated annealing algorithm that bases on graph data structure.
    /// </summary>
    public class SimulatedAnnealing : Algorithm
    {
        private readonly Random _random = new Random();
        private long _processorTimeCost = long.MaxValue;
        
        /// <summary>
        /// Creates SimulatedAnnealing algorithm instance
        /// </summary>
        /// <param name="graph">Graph on which algorithm will operate</param>
        /// <param name="problem">Problem for which algorithm will attempt to find solution</param>
        /// <param name="setup">Setup for algorithm's cooling process</param>
        public SimulatedAnnealing(Graph graph, IProblem problem, CoolingSetup setup) : base(graph, problem)
        {
            if (setup == null)
                throw new ArgumentNullException(nameof(setup));
            if (!setup.IsValid())
                throw new ArgumentException("Setup is invalid", nameof(setup));
            CoolingSetup = setup;
        }

        /// <summary>
        /// Current system temperature.
        /// </summary>
        public double CurrentTemperature { get; private set; }

        /// <summary>
        /// Target temperature for cooling. System cannot be cooled below that value, ie. it's system zero temp.
        /// </summary>
        public double MinimalTemperature { get { return 0.001f; } }

        /// <summary>
        /// Processor time cost in ticks (1 tick = 100 ns).
        /// </summary>
        public override long ProcessorTimeCost { get { return _processorTimeCost; } }

        /// <summary>
        /// Setup of strategy and startup values for cooling. 
        /// </summary>
        public CoolingSetup CoolingSetup { get; }

        /// <summary>
        /// Decides whether algorithm should accept new solution.
        /// </summary>
        /// <param name="proposedSolution">New solution found by algorithm.</param>
        /// <returns>Decision if algorithm should accept answer.</returns>
        public override bool CanAcceptAnswer(ICollection<Node> proposedSolution)
        {
            if (proposedSolution == null) throw new ArgumentNullException(nameof(proposedSolution));
            int solutionOutcome = Problem.SolutionOutcome(proposedSolution);
            return AcceptanceProbability(Problem.CurrentOutcome, solutionOutcome) > _random.NextDouble();
        }

        /// <summary>
        /// Decides whether algorithm can proceed with next step of solution searching.
        /// </summary>
        /// <returns>Decision if algorithm can proceed.</returns>
        public override bool CanContinueSearching()
        {
            return CurrentTemperature > MinimalTemperature;
        }

        /// <summary>
        /// Searches for solution for chosen problem.
        /// </summary>
        protected override IEnumerable<IAlgorithmProgressReport> SearchForSolution()
        {
            RestartSystem();
            return CoolSystem();
        }

        /// <summary>
        /// Cools system until cooling strategy minimal temperature is met.
        /// </summary>
        private IEnumerable<IAlgorithmProgressReport> CoolSystem()
        {
            return CoolingSetup.CoolingStrategy.Cool(this, CoolOnce);
        }

        /// <summary>
        /// Calculates probability of accepting new solution of the problem.
        /// </summary>
        /// <param name="energy">Energy of current solution.</param>
        /// <param name="newEnergy">Energy of new solution.</param>
        /// <returns>Acceptance probability.</returns>
        private double AcceptanceProbability(int energy, int newEnergy)
        {
            if (Problem.Criteria == ProblemCriteria.BiggerIsBetter)
            {
                //Accept if it's better than current one
                if (newEnergy > energy)
                    return 1.0;
                //Calculate probability otherwise
                return Math.Exp((newEnergy - energy) / CurrentTemperature);
            }
            else
            {
                //Accept if it's better than current one
                if (newEnergy < energy)
                    return 1.0;
                //Calculate probability otherwise
                return Math.Exp((energy - newEnergy) / CurrentTemperature);
            }
        }

        //TODO: Go up right to the IAlgorithm?
        /// <summary>
        /// Restarts system to initial state.
        /// </summary>
        private void RestartSystem()
        {
            CurrentTemperature = CoolingSetup.InitialTemperature;
            Problem.RestartProblemState();
            _processorTimeCost = long.MaxValue;
        }

        /// <summary>
        /// Cools system temperature by one step of cooling ratio.
        /// </summary>
        private void CoolOnce()
        {
            CurrentTemperature *= 1 - CoolingSetup.CoolingRate;
        }
    }
}
