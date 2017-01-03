namespace Localwire.Graphinder.WebVisualizer.Models
{
    using System.Collections.Generic;

    public class D3GraphViewModel
    {
        public List<D3NodeViewModel> Nodes { get; set; }
        public List<D3EdgeViewModel> Edges { get; set; }
    }
}