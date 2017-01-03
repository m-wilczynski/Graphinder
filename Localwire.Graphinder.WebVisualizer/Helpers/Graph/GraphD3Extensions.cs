namespace Localwire.Graphinder.WebVisualizer.Helpers.Graph
{
    using System.Linq;
    using Core.Graph;
    using Models;

    public static class GraphD3Extensions
    {
        public static D3GraphViewModel AsD3ViewModel(this Graph graph)
        {
            return new D3GraphViewModel
            {
                Nodes = graph.Nodes.Select(n => new D3NodeViewModel {Key = n.Key}).ToList(),
                Edges = graph.Edges.Select(e => new D3EdgeViewModel {Source = e.From.Key, Target = e.To.Key}).ToList()
            };
        }
    }
}