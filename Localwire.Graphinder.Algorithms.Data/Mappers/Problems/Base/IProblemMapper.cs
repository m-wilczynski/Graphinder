namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Problems.Base
{
    using Core.Problems;
    using Entities.Problems;

    public interface IProblemMapper
    {
        IProblem ToDomainModel(ProblemEntity entity);
        ProblemEntity ToEntityModel(IProblem model);
    }
}