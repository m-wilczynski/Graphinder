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
        /// Decides whether algorithm should accept new solution.
        /// </summary>
        /// <param name="proposedSolution">New solution found by algorithm.</param>
        /// <returns>Decision if algorithm should accept answer.</returns>
        public abstract bool CanAcceptAnswer(int proposedSolution);


        /// <summary>
        /// Decides whether algorithm can proceed with next step of solution searching.
        /// </summary>
        /// <returns>Decision if algorithm can proceed.</returns>
        public abstract bool CanContinueSearching();

        /// <summary>
        /// Searches for solution for chosen problem.
        /// </summary>
        protected abstract void SearchForSolution();
    }
}
