namespace Localwire.Graphinder.Algorithms.DTO.Administration.WorkerRegistration
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class WorkerRegistrationFinalization
    {
        [Required]
        public bool HasSuccessfullyConnectedToDatabase { get; set; }
        public Exception ConnectionException { get; set; }
    }
}
