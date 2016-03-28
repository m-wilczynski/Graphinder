namespace Localwire.Graphinder.Core.Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    using Graph;
    using Problems;
    using Reports;

    public abstract class Algorithm : IAlgorithm
    {
        //TODO: Move up as prop
        public Guid Id;

        private IAlgorithmProgressReport _currentProgressReport;
        private IObservable<IAlgorithmProgressReport> _progressReportObservable; 
        
        protected Algorithm(Graph graph, IProblem problem)
        {
            if (problem == null)
                throw new ArgumentNullException(nameof(problem));
            if (graph == null)
                throw new ArgumentNullException(nameof(graph));
            if (!graph.IsValid())
                throw new ArgumentException("Graph is invalid", nameof(graph));
            Id = Guid.NewGuid();
            Graph = graph;
            Problem = problem;
            problem.Initialize(graph);
        }

        /// <summary>
        /// Problem for which algorithm will search for solution.
        /// </summary>
        public IProblem Problem { get; }

        /// <summary>
        /// Processor time cost in ticks (1 tick = 100 ns).
        /// </summary>
        public abstract long ProcessorTimeCost { get; protected set; }

        /// <summary>
        /// Graph on which algorithm operate.
        /// </summary>
        public Graph Graph { get; }

        public IAlgorithmProgressReport CurrentProgressReport
        {
            get { return _currentProgressReport; }
            set
            {
                if (value.Equals(_currentProgressReport)) return;
                _currentProgressReport = value;
            }
        }

        public IObservable<IAlgorithmProgressReport> ProgressReportChanged
        {
            get { return _progressReportObservable; }
        } 

        /// <summary>
        /// Launches algorithm and searches for solution.
        /// Intended as template pattern.
        /// </summary>
        public void LaunchAlgorithm()
        {
            Graph.LockGraph();
            _progressReportObservable = SearchForSolution().ToObservable(Scheduler.Default);
            _progressReportObservable.Subscribe(OnProgressChanged);
        }

        /// <summary>
        /// Decides whether algorithm should accept new solution.
        /// </summary>
        /// <param name="proposedSolution">New solution found by algorithm.</param>
        /// <returns>Decision if algorithm should accept answer.</returns>
        public abstract bool CanAcceptAnswer(ICollection<Node> proposedSolution);


        /// <summary>
        /// Decides whether algorithm can proceed with next step of solution searching.
        /// </summary>
        /// <returns>Decision if algorithm can proceed.</returns>
        public abstract bool CanContinueSearching();

        /// <summary>
        /// Searches for solution for chosen problem.
        /// </summary>
        protected abstract IEnumerable<IAlgorithmProgressReport> SearchForSolution();

        /// <summary>
        /// Action performed on solution finding progress change
        /// </summary>
        /// <param name="algorithmProgress"></param>
        protected virtual void OnProgressChanged(IAlgorithmProgressReport algorithmProgress)
        {
            CurrentProgressReport = algorithmProgress;
            ProcessorTimeCost = algorithmProgress.ProcessorTime;
        }
    }
}
