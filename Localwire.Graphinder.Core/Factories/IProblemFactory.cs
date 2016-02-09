namespace Localwire.Graphinder.Core.Factories
{
    using Problems;

    public interface IProblemFactory
    {
        /// <summary>
        /// Provides specific NP problem instance.
        /// </summary>
        /// <returns>Instance of problem.</returns>
        IProblem Provide();
    }
}
