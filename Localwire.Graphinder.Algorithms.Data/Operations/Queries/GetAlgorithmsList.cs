namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Queries
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Entities.DataSpecific;

    //TODO: Map to DTO + edges count
    public class GetAlgorithmsList : SqlServerOperation, IQueryManyOperation<AlgorithmListElement>
    {
        public async Task<ICollection<AlgorithmListElement>> QueryAsync()
        {
            var queriedList = await Context.Algorithms
                .Include(algh => algh.Graph)
                .Include(algh => algh.Problem)
                .ToListAsync();
            return queriedList.Select(algorithm =>
                new AlgorithmListElement
                {
                    Id = algorithm.Id,
                    AlgorithmType = algorithm.GetType(),
                    ProblemType = algorithm.Problem.GetType(),
                    GraphNodesCount = (uint)algorithm.Graph.Nodes.Count,
                    CurrentProcessorTime = algorithm.TotalProcessorTimeCost
                }).ToList();
        }

        public ICollection<AlgorithmListElement> Query()
        {
            return Context.Algorithms
                .Include(algh => algh.Graph)
                .Include(algh => algh.Problem)
                .Include(algh => algh.Graph.Nodes)
                .ToList()
                .Select(algorithm =>
                new AlgorithmListElement
                {
                    Id = algorithm.Id,
                    AlgorithmType = algorithm.GetType(),
                    ProblemType = algorithm.Problem.GetType(),
                    GraphNodesCount = (uint)algorithm.Graph.Nodes.Count,
                    CurrentProcessorTime = algorithm.TotalProcessorTimeCost
                }).ToList();
        }
    }
}
