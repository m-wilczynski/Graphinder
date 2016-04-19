namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Algorithms.SimulatedAnnealing
{
    using Mappers.EnumMappings.StrategyTypes;

    internal class SimulatedAnnealingEntity : AlgorithmEntity
    {
        public double InitialTemperature { get; set; }
        public double CoolingRate { get; set; }
        public CoolingStrategyType CoolingStrategy { get; set; }
        public double CurrentTemperature { get; set; }
    }
}
