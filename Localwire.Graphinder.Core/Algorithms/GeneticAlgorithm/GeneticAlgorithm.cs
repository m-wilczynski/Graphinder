namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm
{
    using System.Collections.Generic;
    using Graph;
    using Problems;
    using Setup;

    class GeneticAlgorithm : Algorithm
    {
        public GeneticAlgorithm(Graph graph, IProblem problem, 
            GeneticOperators geneticOperators, uint populationSize = 50) : base(graph, problem)
        {
            throw new System.NotImplementedException();
        }

        public override long ProcessorTimeCost { get; }
        public override int CurrentSolution { get; }
        public uint PopulationSize { get; set; }

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
