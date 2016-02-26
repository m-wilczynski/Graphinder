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
            _population = newPopulation;
            _population = _population.OrderBy(p => p.SolutionOutcome).ToList();
            InitializeRoulette();
        }

        public Individual Next()
        {
            if (_population == null || _population.Count == 0)
                throw new InvalidOperationException("Selection strategy needs to have population set first!");
            var totalWeightsSkipped = 0.0;
            foreach (var element in _individualsWeight)
            {
                totalWeightsSkipped += element.Value;
                if (_random.NextDouble() < totalWeightsSkipped)
                    return element.Key;
            }
            return _population.Last();
        }

        public Tuple<Individual, Individual> NextCouple()
        {
            return new Tuple<Individual, Individual>(Next(), Next());
        }

        private void InitializeRoulette()
        {
            _individualsWeight.Clear();
            var populationSum = _population.Sum(p => p.SolutionOutcome);
            foreach(var element in _population)
                _individualsWeight.Add(element, (double)element.SolutionOutcome/populationSum);
        }
    }
}
