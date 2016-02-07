namespace Localwire.Graphinder.Core.Algorithms
{
    using Graph;
    using Problems;

    public abstract class Algorithm : IAlgorithm
    {
        /// <summary>
        /// Problem for which algorithm will search for solution.
        /// </summary>
        public abstract IProblem Problem { get; }

        /// <summary>
        /// Processor time cost in ticks (1 tick = 100 ns).
        /// </summary>
        public abstract long ProcessorTimeCost { get; }

        /// <summary>
        /// Current solution value.
        /// </summary>
        public abstract int CurrentSolution { get; }

        /// <summary>
        /// Graph on which algorithm operate.
        /// </summary>
        public abstract Graph Graph { get; }

        /// <summary>
        /// Launches algorithm and searches for solution.
        /// Intended as template pattern.
        /// </summary>
        public void LaunchAlgorithm()
        {
            SearchForSolution();
        }

        /// <summary>
        /// Searches for solution of given problem.
        /// </summary>
        protected abstract void SearchForSolution();
    }
}
