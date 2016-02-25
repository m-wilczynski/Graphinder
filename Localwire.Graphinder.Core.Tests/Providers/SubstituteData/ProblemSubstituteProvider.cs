namespace Localwire.Graphinder.Core.Tests.Providers.SubstituteData
{
    using System;
    using System.Collections.Generic;
    using Core.Problems;
    using Graph;
    using NSubstitute;

    public class ProblemSubstituteProvider : ISubstituteProvider<IProblem>
    {
        public IProblem ProvideSubstitute()
        {
            var problem = Substitute.For<IProblem>();
            IsSolutionCorrectSetup(problem);
            return problem;
        }

        private void IsSolutionCorrectSetup(IProblem problem)
        {
            problem.When(p => p.IsSolutionCorrect((bool[])null))
                .Do(p => { throw new ArgumentException(); });
            problem.When(p => p.IsSolutionCorrect((ICollection<Node>)null))
                .Do(p => { throw new ArgumentException(); });

            problem.IsSolutionCorrect(Arg.Any<bool[]>()).Returns(true);
            problem.IsSolutionCorrect(Arg.Any<ICollection<Node>>()).Returns(true);
        }
    }
}
