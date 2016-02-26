namespace Localwire.Graphinder.Core.Graph.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class providing utility (generation/parsing) functionalities for graph data structure
    /// </summary>
    public class NodeGenerator
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Generates collection of nodes of given amount and maximum neighbours count
        /// </summary>
        /// <param name="nodeCount">Nodes amount to generate</param>
        /// <param name="maxNeighbours">Maximum neighbours per node</param>
        /// <returns></returns>
        public ICollection<Node> ProvideNodeCollection(uint nodeCount, uint maxNeighbours = 2)
        {
            if (maxNeighbours >= int.MaxValue || nodeCount >= int.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(maxNeighbours));
            if (nodeCount <= maxNeighbours)
                throw new ArgumentOutOfRangeException(nameof(nodeCount), "You cannot have less or equal amount of nodes than max neighbours possible!");

            List<Node> nodes = new List<Node>();

            //Create random nodes
            for (int i = 0; i < nodeCount; i++)
                nodes.Add(new Node(_random.Next().ToString()));

            //Fill neighbours for each one of them
            for (int i = 0; i < nodeCount; i++)
            {
                var howManyNeigbhours = _random.Next((int)maxNeighbours + 1) - nodes[i].Neighbours.Count;
                List<int> alreadyPickedIndexes = new List<int>();
                while (howManyNeigbhours > 0)
                {
                    var pick = _random.Next((int)nodeCount);
                    while (pick == i || alreadyPickedIndexes.Any(p => p == pick))
                        pick = _random.Next((int)nodeCount);
                    nodes[i].AddNeighbour(nodes[pick]);
                    alreadyPickedIndexes.Add(pick);
                    howManyNeigbhours--;
                }
            }
            return nodes;
        }
    }
}
