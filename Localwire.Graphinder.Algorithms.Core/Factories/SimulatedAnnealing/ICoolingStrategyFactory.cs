namespace Localwire.Graphinder.Core.Factories.SimulatedAnnealing
{
    using Algorithms.SimulatedAnnealing.CoolingStrategies;
    using Algorithms.SimulatedAnnealing.Setup;

    public interface ICoolingStrategyFactory
    {
        ICoolingStrategy ProvideOfType(CoolingStrategyType strategyType);
    }
}
