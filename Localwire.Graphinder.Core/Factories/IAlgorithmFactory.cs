namespace Localwire.Graphinder.Core.Factories
{
    using Algorithms;

    public interface IAlgorithmFactory
    {
        /// <summary>
        /// Provides algorith with given setup.
        /// </summary>
        /// <param name="setup">Initial setup for algorithm.</param>
        /// <returns>Instance of algorithm.</returns>
        IAlgorithm Provide(IAlgorithmSetup setup);
    }
}
