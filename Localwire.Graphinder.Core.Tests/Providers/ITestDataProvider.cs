namespace Localwire.Graphinder.Core.Tests.Providers
{
    public interface ITestDataProvider<T>
    {
        /// <summary>
        /// Provides valid instance of declared type.
        /// </summary>
        /// <returns></returns>
        T ProvideValid();
    }
}
