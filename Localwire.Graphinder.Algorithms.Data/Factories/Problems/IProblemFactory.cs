namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.Problems
{
    using Core.Problems;
    using DataAccess.Problems;

    interface IProblemFactory
    {
        IProblem ProvideOfType(ProblemEntity entity);
    }
}
