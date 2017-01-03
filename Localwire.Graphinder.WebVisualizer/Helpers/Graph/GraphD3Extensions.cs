namespace Localwire.Graphinder.WebVisualizer.Helpers.Graph
{
    using System;
    using System.Linq;
    using Core.Graph;
    using Models;

    public static class GraphD3Extensions
    {
        private static Random _random = new Random(12344321);

        public static D3GraphViewModel AsD3ViewModel(this Graph graph, uint nodeGroups = 10)
        {
            return new D3GraphViewModel
            {
                Nodes = graph.Nodes.Select(n => new D3NodeViewModel { Key = n.Key, ColorGroup = _random.Next(1, (int)nodeGroups) }).ToList(),
                Edges = graph.Edges.Select(e => new D3EdgeViewModel { Source = e.From.Key, Target = e.To.Key }).ToList()
            };
        }
    }
}