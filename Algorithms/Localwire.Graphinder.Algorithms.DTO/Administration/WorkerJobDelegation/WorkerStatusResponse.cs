namespace Localwire.Graphinder.Algorithms.DTO.Administration.WorkerJobDelegation
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class WorkerStatusResponse
    {
        [Required]
        public bool IsBusy { get; set; }
        public Guid? CurrentlyWorkedAlgorithmInstance { get; set; }
    }
}
