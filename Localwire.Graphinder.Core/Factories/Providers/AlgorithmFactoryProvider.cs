namespace Localwire.Graphinder.Core.Factories.Providers
{
    using System;
    using System.Collections.Generic;
    using Algorithms.OptimizationAlgorithms.SimulatedAnnealing;
    using Algorithms.OptimizationAlgorithms.SimulatedAnnealing.Setup;

    public class AlgorithmFactoryProvider
    {
        //TODO: Not ideal, isn't it?
        private static readonly IDictionary<Type, IAlgorithmFactory> FactoriesForTypes = 
            new Dictionary<Type, IAlgorithmFactory>
            {
                { typeof(SimulatedAnnealing), new SimulatedAnnealingFactory() },
            };

        /// <summary>
        /// Provides factory for given algorithm.
        /// </summary>
        /// <typeparam name="T">Type of algorithm meant to be built by provided factory.</typeparam>
        /// <returns>Factory for given algorithm if found. Null otherwise.</returns>
        public IAlgorithmFactory ProvideFactoryFor<T>() where T : IAlgorithmFactory
        {
            IAlgorithmFactory factory;
            FactoriesForTypes.TryGetValue(typeof (T), out factory);
            return factory;
        }
    }
}
