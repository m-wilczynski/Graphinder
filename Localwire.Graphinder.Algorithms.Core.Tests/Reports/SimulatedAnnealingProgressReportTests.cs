namespace Localwire.Graphinder.Core.Tests.Reports
{
    using System;
    using Core.Reports.AlgorithmReports.SimulatedAnnealing;
    using Xunit;

    public class SimulatedAnnealingProgressReportTests : IAlgorithmProgressReportTests
    {
        private uint _validTemperature = 1;

        [Fact]
        public override void IAlgorithmProgressReport_ctor_ThrowOnNullSolution()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new SimulatedAnnealingProgressReport(ValidProcessorTime, null, ValidFitness, _validTemperature);
            });
        }

        [Fact]
        public override void IAlgorithmProgressReport_ctor_ThrowOnNegativeProcessorTime()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new SimulatedAnnealingProgressReport(-1, ValidSolution, ValidFitness, _validTemperature);
            });
        }
    }
}
