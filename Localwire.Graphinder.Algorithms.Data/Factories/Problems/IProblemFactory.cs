namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.Problems
{
    using Core.Problems;
    using Entities.Problems;

    interface IProblemFactory
    {
        IProblem ProvideOfType(ProblemEntity entity);
    }
}
