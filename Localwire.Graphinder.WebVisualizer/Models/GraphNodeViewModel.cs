namespace Localwire.Graphinder.WebVisualizer.Models
{
    using System.Collections.Generic;

    public class GraphNodeViewModel
    {
        public string Key { get; set; }
        public ICollection<string> Neighbours { get; set; }
    }
}