namespace Localwire.Graphinder.Algorithms.Service.Configuration.Base
{
    using System;
    using DataAccess.EntityFramework;

    public interface IConnectionTester
    {
        bool IsAddressDead(Uri address, uint repeats, TimeSpan repeatInterval);
        bool CanConnectToDatabase(IDatabaseConfiguration configuration);
    }
}
