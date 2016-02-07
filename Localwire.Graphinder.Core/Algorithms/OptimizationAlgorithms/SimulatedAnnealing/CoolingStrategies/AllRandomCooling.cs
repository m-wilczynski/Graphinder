namespace Localwire.Graphinder.Core.Algorithms.OptimizationAlgorithms.SimulatedAnnealing.CoolingStrategies
{
    using System;
    using System.Collections.Generic;
    using Graph;

    /// <summary>
    /// Class representing all random cooling strategy.
    /// New solution is being found by polling for random nodes until soluton correctness criteria is met.
    /// </summary>
    public class AllRandomCooling : ICoolingStrategy
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Target temperature for cooling. System cannot be cooled below that value, ie. it's system zero temp.
        /// </summary>
        public float CoolingTargetTemperature { get { return 0.001f; } }

        /// <summary>
        /// Cools system until it reaches minimal, targeted temperature.
        /// </summary>
        /// <param name="algorithm">Simulated annealing algorithm being cooled.</param>
        /// <param name="coolingAction">Delegate of action to cool system by one step of cooling ratio.</param>
        /// <returns>Processor time cost</returns>
        public long Cool(SimulatedAnnealing algorithm, Action coolingAction)
        {
            var startTime = DateTime.Now.Ticks;
            var counter = 0;
            while (algorithm.CurrentTemperature > CoolingTargetTemperature)
            {
                //Previous values
                var energy = algorithm.Problem.CurrentOutcome;
                var previousSolution = algorithm.Problem.CurrentSolution;

                //Pick random node from graph and keep on adding them to solution until correctness criteria is met
                HashSet<Node> proposedSolution = new HashSet<Node>();
                algorithm.Problem.AddNewSolution(proposedSolution);
                while (!algorithm.Problem.IsCurrentSolutionCorrect)
                {
                    proposedSolution.Add(algorithm.Graph.GetRandomNode());
                    algorithm.Problem.AddNewSolution(proposedSolution);
                }

                //Rollback if solution has not been accepted
                if (algorithm.AcceptanceProbability(energy, algorithm.CurrentSolution) < _random.NextDouble())
                    algorithm.Problem.AddNewSolution(previousSolution);

                //Cool system
                coolingAction();
            }
            return DateTime.Now.Ticks - startTime;
        }
    }
}
