namespace Localwire.Graphinder.Algorithms.DataAccess.EntityFramework
{
    using System.Data.Entity;

    internal class InitialConfiguration : CreateDatabaseIfNotExists<AlgorithmContext>
    {



        protected override void Seed(AlgorithmContext context)
        {
            base.Seed(context);
        }
    }
}
