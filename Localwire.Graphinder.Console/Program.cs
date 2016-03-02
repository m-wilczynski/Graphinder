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
            graph.FillGraphRandomly(50, 6);

            var alghs = new List<IAlgorithm>
            {
                new SimulatedAnnealing.Builder()
                    .WithSetupData(new SimulatedAnnealingSetup(
                        graph, new MinimumVertexCover(),
                        new CoolingSetup(1000, 0.03, new AllRandomCooling())))
                    .Build(),
                new SimulatedAnnealing.Builder()
                    .WithSetupData(new SimulatedAnnealingSetup(
                        graph, new MinimumVertexCover(),
                        new CoolingSetup(1000, 0.03, new AllRandomCooling())))
                    .Build(),
                new SimulatedAnnealing.Builder()
                    .WithSetupData(new SimulatedAnnealingSetup(
                        graph, new MinimumVertexCover(),
                        new CoolingSetup(1000, 0.03, new AllRandomCooling())))
                    .Build()
            };
            foreach (var algh in alghs)
            {
                System.Console.WriteLine(algh.CurrentSolution);
            }

            foreach (var algh in alghs)
                algh.LaunchAlgorithm();

            foreach (var algh in alghs)
            {
                Console.WriteLine(algh.CurrentSolution);
            }

            Console.ReadKey();
        }
    }
}
