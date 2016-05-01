namespace Localwire.Graphinder.Core.Tests.Providers.TestData
{
    using System.Collections.Generic;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Graph;
    using Core.Problems;
    using SubstituteData;

    public class IndividualsProvider : ITestDataProvider<ICollection<Individual>>
    {
        private readonly ITestDataProvider<Graph> _graphProvider = new GraphProvider();
        private readonly ISubstituteProvider<IProblem> _problemProvider = new ProblemSubstituteProvider();

        /// <summary>
        /// Provides valid instance of declared type.
        /// </summary>
        /// <returns></returns>
        public ICollection<Individual> ProvideValid()
        {
            var graph = _graphProvider.ProvideValid();
            var problem = _problemProvider.ProvideSubstitute();
            return new List<Individual> {
                new Individual(graph, problem),
                new Individual(graph, problem),
                new Individual(graph, problem)
                };
        }
    }
}
