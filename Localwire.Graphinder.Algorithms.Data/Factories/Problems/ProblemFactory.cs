namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.Problems
{
    using Core.Problems;
    using Core.Problems.OptimizationProblems;
    using DataAccess.Problems;
    using EnumMappings.ProblemTypes;

    public class ProblemFactory : IProblemFactory
    {
        public IProblem ProvideOfType(ProblemEntity entity)
        {
            switch (entity.ProblemType)
            {
                case ProblemType.MinimumVertexCover:
                    return new MinimumVertexCover();
                case ProblemType.None:
                    return null;
                default:
                    return null;
            }
        }
    }
}
