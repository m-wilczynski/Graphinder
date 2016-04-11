namespace Localwire.Graphinder.Algorithms.DataAccess.Algorithms.SimulatedAnnealing
{
    using EnumMappings.StrategyTypes;

    public class SimulatedAnnealingEntity : AlgorithmEntity
    {
        public double InitialTemperature { get; set; }
        public double CoolingRate { get; set; }
        public CoolingStrategyType CoolingStrategy { get; set; }
        public double CurrentTemperature { get; set; }
    }
}
