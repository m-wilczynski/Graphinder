
namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm
{
    using System;
    using System.Linq;
    using Graph;
    using Problems;

    /// <summary>
    /// Individual (atomic element of a population) holding solution to given problem.
    /// </summary>
    public class Individual
    {
        private readonly Random _random = new Random();
        private readonly Graph _graph;
        private readonly IProblem _problem;
        private readonly bool[] _currentSolution;
        private readonly uint _totalSize;
        private int _currentOutcome;

        public Individual(Graph graph, IProblem problem, bool[] solution = null)
        {
            if (graph == null || problem == null) throw new ArgumentException("Neither graph nor problem can be null!");
            if (!graph.IsValid()) throw new ArgumentException(nameof(graph) + " is not valid!");
            _graph = graph;
            _problem = problem;
            _totalSize = (uint)_graph.TotalNodes;
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
        }
        
        //TODO: Are those three accessors needed anyway? 
        //      3x public readonly would suffice,
        //      yet it would be quite inflexible.
        public IProblem Problem { get { return _problem; } }

        public bool[] CurrentSolution { get { return _currentSolution; } }

        public int SolutionOutcome { get { return _currentOutcome; } }

        //TODO: Should be dependent on IProblem's criterias!
        public uint SolutionFitness { get { return Convert.ToUInt32(_graph.TotalNodes - SolutionOutcome) + 1; } }

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
