namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Base
{
    using System.Threading.Tasks;

    public interface ICommandOperation
    {
        bool Execute();
        Task<bool> ExecuteAsync();
    }
}
