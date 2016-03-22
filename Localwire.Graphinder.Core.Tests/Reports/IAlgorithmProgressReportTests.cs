namespace Localwire.Graphinder.Core.Tests.Reports
{
    using System.Collections.Generic;
    using Core.Graph;

    public abstract class IAlgorithmProgressReportTests
    {
        protected uint ValidFitness = 1;
        protected long ValidProcessorTime = 1;
        protected ICollection<Node> ValidSolution = new List<Node>();

        public abstract void IAlgorithmProgressReport_ctor_ThrowOnNullSolution();
        public abstract void IAlgorithmProgressReport_ctor_ThrowOnNegativeProcessorTime();
    }
}
