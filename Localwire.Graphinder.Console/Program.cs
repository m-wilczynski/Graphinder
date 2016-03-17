namespace Localwire.Graphinder.ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using Core.Algorithms;
    using Core.Algorithms.SimulatedAnnealing;
    using Core.Algorithms.SimulatedAnnealing.CoolingStrategies;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using Core.Graph;
    using Core.Problems.OptimizationProblems;

    class Program
    {
        public static void Main()
        {
            var graph = new Graph();
            graph.FillGraphRandomly(50, 5);

            var alghs = new List<IAlgorithm>
            {
                new SimulatedAnnealing(graph, new MinimumVertexCover(),
                    new CoolingSetup(1000, 0.03, new AllRandomCooling())),
                new SimulatedAnnealing(graph, new MinimumVertexCover(),
                    new CoolingSetup(2000, 0.03, new AllRandomCooling())),
                new SimulatedAnnealing(graph, new MinimumVertexCover(),
                    new CoolingSetup(4000, 0.03, new AllRandomCooling()))
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
