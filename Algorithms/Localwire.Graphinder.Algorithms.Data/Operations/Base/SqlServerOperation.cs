namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Base
{
    using EntityFramework;

    public abstract class SqlServerOperation
    {
        internal AlgorithmContext Context = new AlgorithmContext();
    }
}
