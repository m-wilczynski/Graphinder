namespace Localwire.Graphinder.Core.Algorithms.OptimizationAlgorithms.SimulatedAnnealing
{
    using System;
    using CoolingStrategies;
    using Graph;
    using Problems;
    using Setup;

    /// <summary>
    /// Class representing simulated annealing algorithm that bases on graph data structure.
    /// </summary>
    public class SimulatedAnnealing : Algorithm
    {
        private Graph _graph;
        private IProblem _problem;
        private long _processorTimeCost = long.MaxValue;

        private SimulatedAnnealing()
        {
        }

        /// <summary>
        /// Initial system temperature.
        /// </summary>
        public double InitialTemperature { get; private set; }

        /// <summary>
        /// Current system temperature.
        /// </summary>
        public double CurrentTemperature { get; private set; }

        /// <summary>
        /// Rate of cooling the system.
        /// </summary>
        public double CoolingRate { get; private set; }

        /// <summary>
        /// Problem for which algorithm will search for solution.
        /// </summary>
        public override IProblem Problem { get { return _problem; } }

        /// <summary>
        /// Processor time cost in ticks (1 tick = 100 ns).
        /// </summary>
        public override long ProcessorTimeCost { get { return _processorTimeCost; } }

        /// <summary>
        /// Current solution value.
        /// </summary>
        public override int CurrentSolution { get { return _problem.CurrentOutcome; } }

        /// <summary>
        /// Graph on which algorithm operate.
        /// </summary>
        public override Graph Graph { get { return _graph; } }

        /// <summary>
        /// Chosen cooling strategy for annealing.
        /// </summary>
        public ICoolingStrategy CoolingStrategy { get; private set; }

        /// <summary>
        /// Searches for solution for chosen problem.
        /// </summary>
        protected override void SearchForSolution()
        {
            RestartSystem();
            CoolSystem();
        }

        /// <summary>
        /// Cools system until cooling strategy minimal temperature is met.
        /// </summary>
        public void CoolSystem()
        {
            _processorTimeCost = CoolingStrategy.Cool(this, CoolOnce);
        }

        /// <summary>
        /// Calculates probability of accepting new solution of the problem.
        /// </summary>
        /// <param name="energy">Energy of current solution.</param>
        /// <param name="newEnergy">Energy of new solution.</param>
        /// <returns>Acceptance probability.</returns>
        public double AcceptanceProbability(int energy, int newEnergy)
        {
            if (_problem.Criteria == ProblemCriteria.BiggerIsBetter)
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

        /// <summary>
        /// Restart system to initial state.
        /// </summary>
        private void RestartSystem()
        {
            CurrentTemperature = InitialTemperature;
            _problem.RestartProblemState();
            _processorTimeCost = long.MaxValue;
        }

        /// <summary>
        /// Cool system temperature by one step of cooling ratio.
        /// </summary>
        private void CoolOnce()
        {
            CurrentTemperature *= 1 - CoolingRate;
        }

        /// <summary>
        /// Builder of Simulated Annealing algorithm instance.
        /// </summary>
        public class Builder
        {
            private readonly SimulatedAnnealing _builtAlgorithm;
            private bool _isBuilt;

            public Builder()
            {
                _builtAlgorithm = new SimulatedAnnealing();
            }

            public Builder WithSetupData(SimulatedAnnealingSetup setup)
            {
                if (!setup.IsValid) throw new ArgumentException("Setup state is invalid!", nameof(setup));
                _builtAlgorithm._graph = setup.Graph;
                _builtAlgorithm._problem = setup.Problem;
                _builtAlgorithm._problem.Initialize(_builtAlgorithm._graph);
                _builtAlgorithm.CoolingStrategy = setup.CoolingSetup.CoolingStrategy;
                _builtAlgorithm.InitialTemperature = setup.CoolingSetup.InitialTemperature;
                _builtAlgorithm.CoolingRate = setup.CoolingSetup.CoolingRate;
                return this;
            }

            public SimulatedAnnealing Build()
            {
                if (_isBuilt) return null;
                if (_builtAlgorithm._graph == null) return null;
                _isBuilt = true;
                _builtAlgorithm.RestartSystem();
                return _builtAlgorithm;
            }
        }
    }
}
