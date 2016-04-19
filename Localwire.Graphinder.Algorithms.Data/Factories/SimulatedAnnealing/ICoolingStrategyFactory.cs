namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.SimulatedAnnealing
{
    using Core.Algorithms.SimulatedAnnealing.CoolingStrategies;
    using Mappers.EnumMappings.StrategyTypes;

    public interface ICoolingStrategyFactory
    {
        ICoolingStrategy ProvideOfType(CoolingStrategyType strategyType);
    }
}
