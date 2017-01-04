namespace Localwire.Graphinder.WebVisualizer.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class AlgorithmRequestViewModel
    {
        [Required]
        [Range(20, 5000)]
        public uint NumberOfNodesToGenerate { get; set; }

        [Required]
        [Range(2, 50)]
        public uint MaxNeighboursForNode { get; set; }
    }
}