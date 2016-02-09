namespace Localwire.Graphinder.Core.Problems.ProblemFactories
{
    using Factories;
    using OptimizationProblems;

    /// <summary>
    /// Factory for minimal vertex cover problem.
    /// </summary>
    public class MinimalVertexCoverFactory : IProblemFactory
    {
        public IProblem Provide()
        {
            return new MinimalVertexCover();
        }
    }
}
