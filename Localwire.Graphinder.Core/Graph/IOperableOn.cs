namespace Localwire.Graphinder.Core.Graph
{
    public interface IOperableOn<T>
    {
        /// <summary>
        /// Is problem already initialized?
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        /// Initialize the problem with data structure representing the problem.
        /// </summary>
        /// <param name="dataStructure">Data structure.</param>
        void Initialize(T dataStructure);
    }
}
