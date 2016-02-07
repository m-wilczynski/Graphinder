namespace Localwire.Graphinder.Core.Algorithms.OptimizationAlgorithms.SimulatedAnnealing.CoolingStrategies
{
    using System;

    /// <summary>
    /// Interface representing behaviour of cooling strategy.
    /// </summary>
    public interface ICoolingStrategy
    {
        /// <summary>
        /// Target temperature for cooling. System cannot be cooled below that value, ie. it's system zero temp.
        /// </summary>
        float CoolingTargetTemperature { get; }

        /// <summary>
        /// Cools system until it reaches minimal, targeted temperature.
        /// </summary>
        /// <param name="algorithm">Simulated annealing algorithm being cooled.</param>
        /// <param name="coolingAction">Delegate of action to cool system by one step of cooling ratio.</param>
        /// <returns>Processor time cost</returns>
        long Cool(SimulatedAnnealing algorithm, Action coolingAction);
    }
}
