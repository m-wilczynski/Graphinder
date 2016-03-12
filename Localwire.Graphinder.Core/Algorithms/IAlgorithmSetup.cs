namespace Localwire.Graphinder.Core.Algorithms
{
    using Graph;
    using Helpers;
    using Problems;

    public interface IAlgorithmSetup<T> : ISelfValidable where T : IAlgorithm
    {
        /// <summary>
        /// Graph on which algorithm operate.
        /// </summary>
        Graph Graph { get; }

        /// <summary>
        /// Problem for which algorithm will search for solution.
        /// </summary>
        IProblem Problem { get; }
    }
}
