namespace Localwire.Graphinder.Core.Algorithms.SimulatedAnnealing.Setup
{
    using System;
    using CoolingStrategies;
    using Helpers;

    /// <summary>
    /// Represents initial setup for simulated annealing cooling
    /// </summary>
    public class CoolingSetup : BaseEntity, ISelfValidable
    {
        /// <summary>
        /// Creates setup for cooling of simulated annealing
        /// </summary>
        /// <param name="initTemp">Initial temperature for system</param>
        /// <param name="coolingRate">Cooling rate of the system</param>
        /// <param name="coolingStrategy">Strategy for cooling the system</param>
        public CoolingSetup(double initTemp, double coolingRate, ICoolingStrategy coolingStrategy, Guid? id = null) : base(id)
        {
            if (coolingRate <= 0)
                throw new ArgumentOutOfRangeException(nameof(coolingRate));
            if (initTemp <= 0)
                throw new ArgumentOutOfRangeException(nameof(initTemp));
            if (coolingStrategy == null)
                throw new ArgumentNullException(nameof(coolingStrategy));
            CoolingRate = coolingRate;
            InitialTemperature = initTemp;
            CoolingStrategy = coolingStrategy;
        }

        /// <summary>
        /// Initial temperature for the system
        /// </summary>
        public double InitialTemperature { get; private set; }

        /// <summary>
        /// Cooling rate for the system
        /// </summary>
        public double CoolingRate { get; private set; }

        /// <summary>
        /// Chosen cooling strategy for annealing.
        /// </summary>
        public ICoolingStrategy CoolingStrategy { get; private set; }

        /// <summary>
        /// Decides if state of object is valid.
        /// </summary>
        public bool IsValid()
        {
            return CoolingRate > 0 && InitialTemperature > 0 && CoolingStrategy != null;
        }
    }
}
