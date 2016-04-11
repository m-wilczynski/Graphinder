namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.SimulatedAnnealing
{
    using Core.Algorithms.SimulatedAnnealing.CoolingStrategies;
    using EnumMappings.StrategyTypes;

    public class CoolingStrategyFactory : ICoolingStrategyFactory
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
    }
}
