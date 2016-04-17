namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Problems.Base
{
    using Core.Problems;
    using Entities.Problems;

    internal interface IProblemMapperFor<TDomain, TEntity> : IProblemMapper 
        where TDomain : IProblem where TEntity : ProblemEntity
    {
    }
}
