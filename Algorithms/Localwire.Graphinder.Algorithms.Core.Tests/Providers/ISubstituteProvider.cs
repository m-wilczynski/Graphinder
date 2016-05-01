namespace Localwire.Graphinder.Core.Tests.Providers
{
    public interface ISubstituteProvider<T>
    {
        /// <summary>
        /// Provides wired mocked instance of declared type.
        /// </summary>
        /// <returns></returns>
        T ProvideSubstitute();
    }
}
