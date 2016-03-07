using System;

namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.CrossoverStrategies
{
    using Graph;
    using Problems;

    /// <summary>
    /// Klasa reprezentujaca strategie krzyzowania oparta o losowy podzial w jednym punkcie.
    /// </summary>
    public class OnePointCrossoverStrategy : ICrossoverStrategy
    {
        /// <summary>
        /// Minimal crossover point of genotype (percent of genotype).
        /// </summary>
        public const double CrossoverPointMin = 0.2;
        /// <summary>
        /// Maximum crossover point of genotype (percent of genotype).
        /// </summary>
        public const double CrossoverPointMax = 0.8;

        private readonly Random _random = new Random();
        private readonly Graph _graph;
        private readonly IProblem _problem;

        public OnePointCrossoverStrategy(Graph graph, IProblem problem)
        {
            if (graph == null)
                throw new ArgumentNullException(nameof(graph));
            if (!graph.IsValid())
                throw new ArgumentException("Graph is invalid!");
            _graph = graph;
            if (problem == null)
                throw new ArgumentNullException(nameof(problem));
            _problem = problem;
            RandomizeCrossoverPoint();
        }

        public int CrossoverPointIndex { get; private set; }

        public Individual PerformCrossover(Individual leftParent, Individual rightParent)
        {
            var length = leftParent.CurrentSolution.Length >= rightParent.CurrentSolution.Length
                ? leftParent.CurrentSolution.Length
                : rightParent.CurrentSolution.Length;
            var outputSolution = new bool[length];

            for (int i = 0; i < length; i++)
            {
                var el1 = i < leftParent.CurrentSolution.Length ? leftParent.CurrentSolution[i] : false;
                var el2 = i < rightParent.CurrentSolution.Length ? rightParent.CurrentSolution[i] : false;
                if (i < CrossoverPointIndex)
                    outputSolution[i] = el1;
                else
                    outputSolution[i] = el2;
            }
            return new Individual(_graph, _problem, outputSolution);
        }

        private void RandomizeCrossoverPoint()
        {
            //Pick random crossover point between allowed boundries
            double randomized = 0;
            while (randomized > CrossoverPointMin && randomized < CrossoverPointMax)
                randomized = _random.NextDouble();

            var randomIndex = (int)(randomized * _graph.TotalNodes);
            if (randomIndex >= _graph.TotalNodes) randomIndex--;

            CrossoverPointIndex = randomIndex;
        }
    }
}
