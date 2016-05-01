namespace Localwire.Graphinder.Core.Algorithms.SimulatedAnnealing.CoolingStrategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Graph;
    using Reports;
    using Reports.AlgorithmReports.SimulatedAnnealing;

    /// <summary>
    /// Represents all random cooling strategy.
    /// New solution is being found by polling for random nodes until soluton correctness criteria is met.
    /// </summary>
    public class AllRandomCooling : ICoolingStrategy
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Instantiates new all random cooling strategy used to cool <see cref="T:Localwire.Graphinder.Core.Algorithms.SimulatedAnnealing.SimulatedAnnealing"/> based system.
        /// </summary>
        public AllRandomCooling()
        { }

        /// <summary>
        /// Cools system until it reaches minimal, targeted temperature.
        /// </summary>
        /// <param name="algorithm">Simulated annealing algorithm being cooled.</param>
        /// <param name="coolingAction">Delegate of action to cool system by one step of cooling ratio.</param>
        /// <returns>Processor time cost</returns>
        //TODO: Possibly a more narrow dependency to something like ISimulatedAnnealing to not force cast for CurrentTemperature access?
        public IEnumerable<IAlgorithmProgressReport> Cool(IAlgorithm algorithm, Action coolingAction)
        {
            if (algorithm == null) throw new ArgumentException(nameof(algorithm));
            if (coolingAction == null) throw new ArgumentException(nameof(coolingAction));

            var startTime = DateTime.Now.Ticks;
            while (algorithm.CanContinueSearching())
            {
                //Pick random node from graph and keep on adding them to solution until correctness criteria is met
                HashSet<Node> proposedSolution = new HashSet<Node>();
                List<Node> nodesCopy = algorithm.Graph.Nodes;
                Stack<int> randomIndexes = new Stack<int>(Enumerable.Range(0, nodesCopy.Count).OrderBy(r => _random.Next()));
                while (!algorithm.Problem.IsSolutionCorrect(proposedSolution))
                {
                    proposedSolution.Add(nodesCopy[randomIndexes.Pop()]);
                }

                bool wasAccepted = false;

                //Accept the answer if algorithm allows
                if (algorithm.CanAcceptAnswer(proposedSolution))
                {
                    algorithm.Problem.SetNewSolution(proposedSolution);
                    wasAccepted = true;
                }

                var casted = algorithm as SimulatedAnnealing;
                var currentTemp = casted == null ? 0 : casted.CurrentTemperature;

                yield return new SimulatedAnnealingProgressReport(DateTime.Now.Ticks - startTime, algorithm.Problem.CurrentSolution, (uint)(algorithm.Graph.TotalNodes - algorithm.Problem.CurrentSolution.Count + 1), currentTemp, wasAccepted);

                //Cool system
                coolingAction.Invoke();
            }
            
        }
    }
}
