namespace Localwire.Graphinder.Core.Factories.SimulatedAnnealing
{
    using Algorithms.SimulatedAnnealing.CoolingStrategies;
    using Algorithms.SimulatedAnnealing.Setup;

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
