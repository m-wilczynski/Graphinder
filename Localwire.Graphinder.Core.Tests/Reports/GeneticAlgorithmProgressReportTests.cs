namespace Localwire.Graphinder.Core.Tests.Reports
{
    using System;
    using Core.Reports.AlgorithmReports.GeneticAlgorithm;
    using Xunit;

    public class GeneticAlgorithmProgressReportTests : IAlgorithmProgressReportTests
    {
        private uint _validGeneration = 1;

        [Fact]
        public override void IAlgorithmProgressReport_ctor_ThrowOnNullSolution()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new GeneticAlgorithmProgressReport(ValidProcessorTime, null, ValidFitness, _validGeneration);
            });
        }

        [Fact]
        public override void IAlgorithmProgressReport_ctor_ThrowOnNegativeProcessorTime()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new GeneticAlgorithmProgressReport(-1, ValidSolution, ValidFitness, _validGeneration);
            });
        }
    }
}
