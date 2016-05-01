namespace Localwire.Graphinder.Core.Tests.Providers
{
    /// <summary>
    /// Defines operation for providing valid test stubs.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITestDataProvider<T>
    {
        /// <summary>
        /// Provides valid instance of declared type.
        /// </summary>
        /// <returns></returns>
        T ProvideValid();
    }
}
