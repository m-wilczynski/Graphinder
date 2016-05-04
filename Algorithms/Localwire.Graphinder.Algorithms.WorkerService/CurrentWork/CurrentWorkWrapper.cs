namespace Localwire.Graphinder.Algorithms.Service.CurrentWork
{
    using System;
    using System.Threading;
    using Base;
    using Configuration.Base;
    using Core.Algorithms;
    using Core.Reports;
    using System.Reactive;

    public class CurrentWorkWrapper : ICurrentWorkWrapper
    {
        private IWorkerConfiguration _configuration;
        private Thread _currentWorkerThread;
        private IDisposable _progressSubscription;

        public CurrentWorkWrapper(IWorkerConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));
            _configuration = configuration;
        }

        public IAlgorithm CurrentlyWorked { get; private set; }

        public bool CanAcceptWork()
        {
            return CurrentlyWorked == null || !CurrentlyWorked.CanContinueSearching();
        }

        public bool SetCurrentWork(IAlgorithm algorithm)
        {
            if (!CanAcceptWork()) return false;
            if (CurrentlyWorked != null)
            {
                lock (CurrentlyWorked)
                {
                    PersistCurrentWork();
                    _currentWorkerThread.Abort();
                    _progressSubscription.Dispose();
                    CurrentlyWorked = null;
                    _currentWorkerThread = null;
                }
            }
            CurrentlyWorked = algorithm;
            lock (CurrentlyWorked)
            {
                _currentWorkerThread = new Thread(CurrentlyWorked.LaunchAlgorithm);
                _progressSubscription = CurrentlyWorked.ProgressReportChanged.Subscribe(OnProgressReported);
            }
            return true;
        }

        public void PersistCurrentWork()
        {
            //2nd lock attempt in case is called from outside SetCurrentWork
            lock (CurrentlyWorked)
            {
                //Persist
            }
        }

        public void OnProgressReported(IAlgorithmProgressReport report)
        {
            lock (report)
            {
                //Send to Orleans
            }
        }
    }
}
