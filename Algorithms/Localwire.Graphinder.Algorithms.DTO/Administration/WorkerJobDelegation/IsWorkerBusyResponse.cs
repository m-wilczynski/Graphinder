namespace Localwire.Graphinder.Algorithms.DTO.Administration.WorkerJobDelegation
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class IsWorkerBusyResponse
    {
        [Required]
        public bool IsBusy { get; set; }
        public Guid? WorkedAlgorithmInstance { get; set; }
    }
}
