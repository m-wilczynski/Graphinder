namespace Localwire.Graphinder.Algorithms.DTO.Administration.WorkerRegistration
{
    using System.ComponentModel.DataAnnotations;

    public class WorkerRegistration
    {
        [Required]
        public string WorkerName { get; set; }
    }
}
