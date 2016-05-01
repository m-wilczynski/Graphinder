namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.SimulatedAnnealing
{
    using Core.Algorithms.SimulatedAnnealing.CoolingStrategies;
    using Mappers.EnumMappings.StrategyTypes;

    internal class CoolingStrategyFactory : ICoolingStrategyFactory
    {
        public ICoolingStrategy ProvideOfType(CoolingStrategyType strategyType)
        {
            switch (strategyType)
            {
                case CoolingStrategyType.AllRandomCooling:
                    return new AllRandomCooling();
                case CoolingStrategyType.None:
                    return null;
                default:
                    return null;
            }
        }

        public CoolingStrategyType ProvideMappingType(ICoolingStrategy strategy)
        {
            if (strategy is AllRandomCooling)
                return CoolingStrategyType.AllRandomCooling;
            return CoolingStrategyType.None;
        }
    }
}
