namespace Localwire.Graphinder.Core.Tests.Providers
{
    public interface ISubstituteProvider<T>
    {
        T ProvideSubstitute();
    }
}
