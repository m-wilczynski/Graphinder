namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Base
{
    using System;
    using EntityFramework;

    public abstract class SqlServerOperation
    {
        protected SqlServerOperation(IDatabaseConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException();
            Context = new AlgorithmContext(configuration);
        }

        internal AlgorithmContext Context { get; private set; }

        protected abstract void ValidateOperationInputs();
    }
}
