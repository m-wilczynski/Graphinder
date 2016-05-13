namespace Localwire.Graphinder.Algorithms.Service.Configuration
{
    using System;
    using Base;
    using DataAccess.EntityFramework;

    public class ConnectionTester : IConnectionTester
    {
        public bool IsAddressDead(Uri address, uint repeats, TimeSpan repeatInterval)
        {
            throw new NotImplementedException();
        }

        public bool CanConnectToDatabase(IDatabaseConfiguration configuration)
        {
            return true;
            //throw new NotImplementedException();
        }
    }
}
