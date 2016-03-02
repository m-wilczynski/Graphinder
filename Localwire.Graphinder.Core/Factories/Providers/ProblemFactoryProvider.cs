namespace Localwire.Graphinder.Core.Factories.Providers
{
    using System;
    using System.Collections.Generic;
    using Problems;
    using Problems.OptimizationProblems;
    using Problems.ProblemFactories;

    public class ProblemFactoryProvider
    {
        //TODO: Transform into IIndex<T, T1> with Autofac
        private static readonly IDictionary<Type, IProblemFactory> FactoriesForTypes =
            new Dictionary<Type, IProblemFactory>
            {
                { typeof(MinimumVertexCover), new MinimumVertexCoverFactory() },
            };

        /// <summary>
        /// Provides factory for given problem.
        /// </summary>
        /// <typeparam name="T">Type of problem meant to be built by provided factory.</typeparam>
        /// <returns>Factory for given problem if found. Null otherwise.</returns>
        public IProblemFactory ProvideFactoryFor<T>() where T : IProblem
        {
            IProblemFactory factory;
            FactoriesForTypes.TryGetValue(typeof(T), out factory);
            return factory;
        }
    }
}
