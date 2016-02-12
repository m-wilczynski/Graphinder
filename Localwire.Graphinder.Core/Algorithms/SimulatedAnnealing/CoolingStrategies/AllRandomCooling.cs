namespace Localwire.Graphinder.Core.Algorithms.SimulatedAnnealing.CoolingStrategies
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
        /// Cools system until it reaches minimal, targeted temperature.
        /// </summary>
        /// <param name="algorithm">Simulated annealing algorithm being cooled.</param>
        /// <param name="coolingAction">Delegate of action to cool system by one step of cooling ratio.</param>
        /// <returns>Processor time cost</returns>
        public long Cool(IAlgorithm algorithm, Action coolingAction)
        {
            if (algorithm == null) throw new ArgumentException(nameof(algorithm));
            if (coolingAction == null) throw new ArgumentException(nameof(coolingAction));

            var startTime = DateTime.Now.Ticks;
            while (algorithm.CanContinueSearching())
            {
                //Pick random node from graph and keep on adding them to solution until correctness criteria is met
                HashSet<Node> proposedSolution = new HashSet<Node>();
                while (!algorithm.Problem.IsSolutionCorrect(proposedSolution))
                {
                    proposedSolution.Add(algorithm.Graph.GetRandomNode());
                }

                //Rollback if solution has not been accepted
                if (algorithm.CanAcceptAnswer(proposedSolution))
                    algorithm.Problem.AddNewSolution(proposedSolution);

                //Cool system
                coolingAction.Invoke();
            }
            return DateTime.Now.Ticks - startTime;
        }
    }
}
