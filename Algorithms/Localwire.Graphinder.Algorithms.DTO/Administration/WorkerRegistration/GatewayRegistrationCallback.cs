namespace Localwire.Graphinder.Algorithms.DTO.Administration.WorkerRegistration
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GatewayRegistrationCallback
    {
        [Required]
        public Uri DatabaseAddress { get; set; }

        [Required]
        public string InitialCatalog { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
