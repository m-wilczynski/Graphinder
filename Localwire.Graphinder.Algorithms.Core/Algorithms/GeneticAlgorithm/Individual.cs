
namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm
{
    using System;
    using System.Linq;
    using Graph;
    using Problems;

    /// <summary>
    /// Represents single individual (atomic element of a population) holding solution to given problem.
    /// </summary>
    public class Individual : IComparable<Individual>
    {
        public readonly Guid Id;
        //Needed for crossover and passing Graph to offspring
        public readonly Graph Graph;
        public readonly IProblem Problem;

        private readonly Random _random = new Random();
        private readonly bool[] _currentSolution;
        private readonly uint _totalSize;
        private int _currentOutcome;

        public Individual(Graph graph, IProblem problem, bool[] solution = null)
        {
            if (graph == null || problem == null) throw new ArgumentNullException("Neither graph nor problem can be null!");
            if (!graph.IsValid()) throw new ArgumentException("Graph is not valid!");
            Graph = graph;
            Problem = problem;
            _totalSize = (uint)Graph.TotalNodes;
            if (solution == null || solution.Length < _totalSize)
            {
                _currentSolution = new bool[_totalSize];
                RandomizeSolution();
            }
            else
            {
                _currentSolution = solution;
            }
            EnsureCorectness();
            Id = Guid.NewGuid();
        }
        
        public bool[] CurrentSolution { get { return _currentSolution; } }
        public int SolutionOutcome { get { return _currentOutcome; } }

        //TODO: Should be dependent on IProblem's criterias!
        public uint SolutionFitness { get { return Convert.ToUInt32(Graph.TotalNodes - SolutionOutcome) + 1; } }

        public int CompareTo(Individual other)
        {
            if (other == null) return 1;
            var fitnessComparison = SolutionFitness.CompareTo(other.SolutionFitness);
            if (fitnessComparison != 0)
                return fitnessComparison;
            return Id.CompareTo(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var casted = obj as Individual;
            if (casted == null) return false;
            return casted.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Ensure correctness of solution that individual holds
        /// </summary>
        private void EnsureCorectness()
        {
            if (_problem == null) throw new ArgumentException("Problem for individual has not been set");

            //Keep rolling until solution is correct
            while (!_problem.IsSolutionCorrect(_currentSolution))
            {
                for (int i = 0; i < _currentSolution.Length; i++)
                {
                    if (!_currentSolution[i])
                    {
                        _currentSolution[i] = !_currentSolution[i];
                        break;
                    }
                }
            }
            _currentOutcome = _currentSolution.Count(s => s);
        }

        /// <summary>
        /// Randomize initial solution of individual
        /// </summary>
        private void RandomizeSolution()
        {
            for (int i = 0; i < _totalSize; i++)
                _currentSolution[i] = _random.NextDouble() <= 0.5;
        }
    }
}
