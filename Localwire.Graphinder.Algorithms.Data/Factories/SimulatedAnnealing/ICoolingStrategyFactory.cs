namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.SimulatedAnnealing
{
    using Core.Algorithms.SimulatedAnnealing.CoolingStrategies;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using StrategyTypes;

    public interface ICoolingStrategyFactory
    {
        ICoolingStrategy ProvideOfType(CoolingStrategyType strategyType);
    }
}
