namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Graph;
    using Problems;
    using Reports;
    using Reports.AlgorithmReports.GeneticAlgorithm;
    using Setup;

    /// <summary>
    /// Represents genetic algorithm that bases on graph data structure.
    /// </summary>
    public class GeneticAlgorithm : Algorithm
    {
        private bool _isInitialized;
        private readonly Random _random = new Random();
        private long _totalProcessorTimeCost = long.MaxValue;

        /// <summary>
        /// Operators used for breeding new generation of individuals
        /// </summary>
        public readonly GeneticOperators GeneticOperators;

        /// <summary>
        /// Generael settings for solution finding process
        /// </summary>
        public readonly GeneticAlgorithmSettings Settings;

        /// <summary>
        /// Creates instance of genetic algorithm
        /// </summary>
        /// <param name="graph">Graph on which algorithm will operate</param>
        /// <param name="problem">Problem for which algorithm will attempt to find solution</param>
        /// <param name="geneticOperators">Genetic operators used for breeding new generations</param>
        /// <param name="settings">General settings for solution finding process</param>
        /// <param name="startingPopulation">Starting population for algorithm</param>
        public GeneticAlgorithm(Graph graph, IProblem problem, GeneticOperators geneticOperators, 
            GeneticAlgorithmSettings settings, ICollection<Individual> startingPopulation = null, 
            uint currentGeneration = 0, Guid? id = null)
            : base(graph, problem, id)
        {
            if (geneticOperators == null)
                throw new ArgumentNullException(nameof(geneticOperators));
            if (!geneticOperators.IsValid())
                throw new ArgumentException("Genetic operators are not valid", nameof(geneticOperators));
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));
            GeneticOperators = geneticOperators;
            Settings = settings;
            if (startingPopulation == null || startingPopulation.Count == 0 || !startingPopulation.All(IsIndividualValid))
                GenerateInitialPopulation();
            else
            {
                CurrentPopulation = new SortedSet<Individual>();
                foreach (var element in startingPopulation)
                    CurrentPopulation.Add(element);
            }

            CurrentGeneration = currentGeneration;
        }

        /// <summary>
        /// Processor time cost in ticks (1 tick = 100 ns).
        /// </summary>
        public override long TotalProcessorTimeCost
        {
            get { return _totalProcessorTimeCost; }
            protected set { _totalProcessorTimeCost = value; }
        }

        /// <summary>
        /// Current generation number that algorithm bred.
        /// </summary>
        public uint CurrentGeneration { get; private set; }

        /// <summary>
        /// Current population of individuals that algorithm bred.
        /// </summary>
        //TODO: Return copy instead?
        public SortedSet<Individual> CurrentPopulation { get; private set; } 

        /// <summary>
        /// Decides whether algorithm should accept new solution.
        /// </summary>
        /// <param name="proposedSolution">New solution found by algorithm.</param>
        /// <returns>Decision if algorithm should accept answer.</returns>
        public override bool CanAcceptAnswer(ICollection<Node> proposedSolution)
        {
            if (proposedSolution == null)
                throw new ArgumentNullException(nameof(proposedSolution));
            //Always accept in basic implementation
            return true;
        }

        /// <summary>
        /// Decides whether algorithm can proceed with next step of solution searching.
        /// </summary>
        /// <returns>Decision if algorithm can proceed.</returns>
        public override bool CanContinueSearching()
        {
            return CurrentGeneration < Settings.GenerationsToCome;
        }

        /// <summary>
        /// Searches for solution for chosen problem.
        /// </summary>
        protected override IEnumerable<IAlgorithmProgressReport> SearchForSolution()
        {
            ResetToInitialState();

            var startTime = DateTime.Now.Ticks;

            //Look for solution until it reaches last generation
            while (CanContinueSearching())
            {
                SortedSet<Individual> newGeneration = new SortedSet<Individual>();
                SortedSet<Individual> populationToMutate = new SortedSet<Individual>(CurrentPopulation);

                //Elitist selection
                var elite = ElitistSelection();
                if (elite != null)
                {
                    foreach (var element in elite)
                    {
                        newGeneration.Add(element);
                        populationToMutate.Remove(element);
                    }
                }


                //Refresh generation in selection strategy with actual one
                GeneticOperators.SelectionStrategy.Set(populationToMutate);

                //Build new generation of size of previous one
                while (newGeneration.Count < CurrentPopulation.Count)
                {
                    //Choose couple for crossover
                    var couple = GeneticOperators.SelectionStrategy.NextCouple();

                    //Should crossover?
                    Individual newIndividual = null;
                    if (_random.NextDouble() < Settings.CrossoverProbability)
                        //Crossover!
                        newIndividual = GeneticOperators.CrossoverStrategy.PerformCrossover(couple.Item1, couple.Item2);
                    else
                        continue;

                    //Should mutate?
                    if (_random.NextDouble() < Settings.MutationProbability)
                        //Mutate!
                        GeneticOperators.MutationStrategy.Mutate(newIndividual);

                    if (newIndividual != null)
                        newGeneration.Add(newIndividual);
                }

                CurrentGeneration++;
                CurrentPopulation = newGeneration;
                var solutionAsNodes = BestIndividualSolution();
                bool wasAccepted = false;
                if (CanAcceptAnswer(solutionAsNodes))
                {
                    Problem.SetNewSolution(solutionAsNodes);
                    wasAccepted = true;
                }
                yield return new GeneticAlgorithmProgressReport(DateTime.Now.Ticks - startTime, Problem.CurrentSolution, 0, CurrentGeneration, wasAccepted);

            }
            _totalProcessorTimeCost = DateTime.Now.Ticks - startTime;
        }

        private ICollection<Node> BestIndividualSolution()
        {
            return Graph.BinarySolutionAsNodes(CurrentPopulation.Last().CurrentSolution);
        }

        private ICollection<Individual> ElitistSelection()
        {
            if (!Settings.WithElitistSelection) return null;
            if (Settings.EliteSurvivors > int.MaxValue) return null;
            return CurrentPopulation.Reverse().Take((int)Settings.EliteSurvivors).ToList();
        }

        /// <summary>
        /// Restarts system to initial state.
        /// </summary>
        protected override void ResetToInitialState()
        {
            GenerateInitialPopulation();
            Problem.RestartProblemState();
            _totalProcessorTimeCost = long.MaxValue;
        }

        /// <summary>
        /// Generate initial, fully random population
        /// </summary>
        private void GenerateInitialPopulation()
        {
            if (_isInitialized) return;
            CurrentPopulation = new SortedSet<Individual>();
            var counter = Settings.InitialPopulationSize;
            while (counter > 0)
            {
                CurrentPopulation.Add(new Individual(Graph, Problem));
                counter--;
            }
            _isInitialized = true;
        }

        private bool IsIndividualValid(Individual individual)
        {
            return individual.Graph.Equals(Graph) && individual.Problem.Equals(Problem);
        }
    }
}
