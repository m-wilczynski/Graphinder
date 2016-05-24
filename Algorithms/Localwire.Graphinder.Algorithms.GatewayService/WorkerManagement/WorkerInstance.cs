namespace GatewayService.WorkerManagement
{
    using System;

    public class WorkerInstance
    {
        public readonly string Name;
        public readonly Uri Address;

        public WorkerInstance(string name, Uri address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            Name = name;
            Address = address;
        }
    }
}
