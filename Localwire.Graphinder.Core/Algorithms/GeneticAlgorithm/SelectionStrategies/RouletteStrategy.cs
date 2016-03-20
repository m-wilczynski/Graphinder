namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.SelectionStrategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;

    /// <summary>
    /// Represents selection strategy based on roulette wheel aka Fitness Proportionate Selection.
    /// </summary>
    //TODO: Inject ProblemCriteria?
    public class RouletteStrategy : ISelectionStrategy
    {
        private readonly Random _random = new Random();
        private ICollection<Individual> _population;
        private readonly IDictionary<Individual, double> _individualsWeight = new Dictionary<Individual, double>();

        /// <summary>
        /// Instantiates roulette wheel selection strategy used by <see cref="T:Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.GeneticAlgorithm"/>.
        /// </summary>
        public RouletteStrategy()
        { }

        /// <summary>
        /// Resets strategy with new population of individuals.
        /// </summary>
        /// <param name="newPopulation">New population for strategy.</param>
        public void Set(ICollection<Individual> newPopulation)
        {
            if (newPopulation == null)
                throw new ArgumentException(nameof(newPopulation));
            if (newPopulation.Count == 0)
                throw new InvalidOperationException("Attempt to set empty population");
            var problem = newPopulation.First().Problem;
            var graph = newPopulation.First().Graph;
            if (newPopulation.Any(i => i.Graph != graph || i.Problem != problem))
                throw new AlgorithmException("Setting up new population", "Individuals in population represent either different graphs or different problems");
            _population = newPopulation;
            //In case is not SortedSet<T>
            if (!(_population is SortedSet<Individual>))
                _population = _population.OrderBy(p => p.SolutionFitness).ToList();
            InitializeRoulette();
        }

        /// <summary>
        /// Returns randomly chosen individual.
        /// </summary>
        /// <returns></returns>
        public Individual Next()
        {
            if (_population == null || _population.Count == 0)
                throw new InvalidOperationException("Selection strategy needs to have population set first!");
            var randomWeight = _random.NextDouble();
            Individual previous = null;
            foreach (var element in _individualsWeight)
            {
                if (element.Value > randomWeight)
                    return previous ?? element.Key;
                previous = element.Key;
            }
            return previous;
        }

        /// <summary>
        /// Returns randomly chosen pair of individuals.
        /// </summary>
        /// <returns></returns>
        public Tuple<Individual, Individual> NextCouple()
        {
            if (_population.Count < 2)
                throw new InvalidOperationException("Cannot choose two different individuals from population smaller than 2.");
            Individual first = Next();
            Individual second = null;
            while (second == null || second.Equals(first))
            {
                second = Next();
            }

            return new Tuple<Individual, Individual>(first, second);
        }

        private void InitializeRoulette()
        {
            _individualsWeight.Clear();
            var populationSum = _population.Sum(p => p.SolutionFitness);
            var probabilitiesSum = 0d;
            foreach (var element in _population)
            {
                var probability = (double) element.SolutionFitness/populationSum;
                _individualsWeight.Add(element, probabilitiesSum + probability);
                probabilitiesSum += probability;
            }
        }
    }
}
