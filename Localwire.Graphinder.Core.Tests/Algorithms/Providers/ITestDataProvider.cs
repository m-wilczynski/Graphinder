namespace Localwire.Graphinder.Core.Tests.Algorithms.Providers
{
    public interface ITestDataProvider<T>
    {
        T ProvideValid();
    }
}
