namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Commands
{
    using System.Linq;
    using Core.Problems;

    public class UpdateProblem : SqlServerOperation
    {
        public UpdateProblem(IProblem problem)
        {

        }

        public void Run()
        {
            Context.Algorithms.ToList();
        }
    }
}
