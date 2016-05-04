namespace Localwire.Graphinder.Algorithms.Service.Configuration.Base
{
    using System;

    public interface IConnectionTester
    {
        bool IsAddressDead(uint repeats, TimeSpan repeatInterval);
    }
}
