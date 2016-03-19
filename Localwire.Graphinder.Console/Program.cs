namespace Localwire.Graphinder.ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using Core.Algorithms;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using Core.Algorithms.GeneticAlgorithm.MutationStrategies;
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;
    using Core.Algorithms.GeneticAlgorithm.Setup;
    using Core.Algorithms.SimulatedAnnealing;
    using Core.Algorithms.SimulatedAnnealing.CoolingStrategies;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using Core.Graph;
    using Core.Helpers.Operations.Binary;
    using Core.Problems.OptimizationProblems;

    class Program
    {
        public static void Main()
        {
            var graph = new Graph();
            graph.FillGraphRandomly(100, 5);

            var alghs = new List<IAlgorithm>
            {
                new SimulatedAnnealing(graph, new MinimumVertexCover(),
                    new CoolingSetup(1000, 0.03, new AllRandomCooling())),
                new SimulatedAnnealing(graph, new MinimumVertexCover(),
                    new CoolingSetup(2000, 0.03, new AllRandomCooling())),
                new SimulatedAnnealing(graph, new MinimumVertexCover(),
                    new CoolingSetup(4000, 0.03, new AllRandomCooling())),
                new GeneticAlgorithm(graph, new MinimumVertexCover(),
                    new GeneticOperators(new RouletteStrategy(), new OnePointCrossoverStrategy(graph), new BinaryTransformationStrategy(BinaryTransformationType.RandomBitFlip)),
                    new GeneticAlgorithmSettings(40, 50, 0.5f, 0.3f)),
                new GeneticAlgorithm(graph, new MinimumVertexCover(),
                    new GeneticOperators(new RouletteStrategy(), new OnePointCrossoverStrategy(graph), new BinaryTransformationStrategy(BinaryTransformationType.RandomBitFlip)),
                    new GeneticAlgorithmSettings(40, 50, 0.5f, 0.3f, true))
            };
            foreach (var algh in alghs)
            {
                System.Console.WriteLine(algh.Problem.CurrentOutcome);
            }

            foreach (var algh in alghs)
                algh.LaunchAlgorithm();

            foreach (var algh in alghs)
            {
                Console.WriteLine(algh.Problem.CurrentOutcome);
            }

            Console.ReadKey();
        }
    }
}
