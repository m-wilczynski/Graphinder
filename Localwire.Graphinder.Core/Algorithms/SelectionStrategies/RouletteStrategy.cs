namespace Localwire.Graphinder.Core.Algorithms.SelectionStrategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GeneticAlgorithm;

    /// <summary>
    /// Class representing selection strategy based on roulette wheel aka Fitness Proportionate Selection.
    /// </summary>
    //TODO: Inject ProblemCriteria?
    public class RouletteStrategy : ISelectionStrategy
    {
        private readonly Random _random = new Random();
        private ICollection<Individual> _population;
        private readonly IDictionary<Individual, double> _individualsWeight = new Dictionary<Individual, double>();

        public void Set(ICollection<Individual> newPopulation)
        {
            if (newPopulation == null)
                throw new ArgumentException(nameof(newPopulation));
            _population = newPopulation;
            _population = _population.OrderBy(p => p.SolutionFitness).ToList();
            InitializeRoulette();
        }

        public Individual Next()
        {
            if (_population == null || _population.Count == 0)
                throw new InvalidOperationException("Selection strategy needs to have population set first!");
            var totalWeightsSkipped = 0.0;
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

        public Tuple<Individual, Individual> NextCouple()
        {
            return new Tuple<Individual, Individual>(Next(), Next());
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
