namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm
{
    using System.Collections.Generic;
    using Graph;
    using Problems;

    class GeneticAlgorithm : Algorithm
    {
        public override long ProcessorTimeCost { get; }
        public override int CurrentSolution { get; }
        
        public GeneticAlgorithm(Graph graph, IProblem problem) : base(graph, problem)
        {
        }

        public override bool CanAcceptAnswer(ICollection<Node> proposedSolution)
        {
            throw new System.NotImplementedException();
        }

        public override bool CanContinueSearching()
        {
            throw new System.NotImplementedException();
        }

        protected override void SearchForSolution()
        {
            throw new System.NotImplementedException();
        }
    }
}
