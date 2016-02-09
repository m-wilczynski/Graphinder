namespace Localwire.Graphinder.Core.Algorithms.OptimizationAlgorithms.SimulatedAnnealing.Setup
{
    using System;
    using Factories;

    /// <summary>
    /// Factory for simulated annealing algorithm.
    /// </summary>
    public class SimulatedAnnealingFactory : IAlgorithmFactory
    {
        /// <summary>
        /// Provides intance of simulated annealing algorithm, provided setup is correct.
        /// </summary>
        /// <param name="setup">Setup for initializing algorithm.</param>
        /// <returns></returns>
        public IAlgorithm Provide(IAlgorithmSetup setup)
        {
            var castedSetup = setup as SimulatedAnnealingSetup;
            if (castedSetup == null)
                throw new ArgumentException("Provided setup is invalid for requested algorithm!", nameof(setup));
            if (!castedSetup.IsValid)
                throw new ArgumentException("Setup state is invalid!", nameof(setup));

            return new SimulatedAnnealing.Builder()
                .WithSetupData(castedSetup)
                .Build();

        }
    }
}
