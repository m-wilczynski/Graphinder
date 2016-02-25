namespace Localwire.Graphinder.Core.Tests.Providers
{
    public interface ITestDataProvider<T>
    {
        T ProvideValid();
    }
}
