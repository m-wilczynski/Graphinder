namespace Localwire.Graphinder.ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using Algorithms.DataAccess.Entities.DataSpecific;
    using Algorithms.DataAccess.Operations.Commands;
    using Algorithms.DataAccess.Operations.Queries;
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
            RunFewAlgorithms();
            //ReadAlgorithmsFromDb();

            while (true)
            {
                if (Console.ReadLine() == "exit") break;
            }
        }

        //private static void ReadAlgorithmsFromDb()
        //{
        //    var algorithms = new GetAlgorithmsList().Query();

        //    foreach (AlgorithmListElement alg in algorithms)
        //    {
        //        Console.WriteLine(
        //            $"Algorithm of ID [{alg.Id}] of type {alg.AlgorithmType.Name}" + Environment.NewLine +
        //            $"Problem of type: {alg.ProblemType.Name} | Graph nodes: {alg.GraphNodesCount}" + Environment.NewLine);
        //    }
        //}

        private static void RunFewAlgorithms()
        {
            var graph = new Graph();
            graph.FillGraphRandomly(400, 5);

            //new AddGraph(graph).Execute();

            var alghs = new List<Algorithm>
            {
                //new SimulatedAnnealing(graph, new MinimumVertexCover(),
                //    new CoolingSetup(1000, 0.03, new AllRandomCooling())),
                //new SimulatedAnnealing(graph, new MinimumVertexCover(),
                //    new CoolingSetup(2000, 0.03, new AllRandomCooling())),
                //new SimulatedAnnealing(graph, new MinimumVertexCover(),
                //    new CoolingSetup(4000, 0.03, new AllRandomCooling())),
                new GeneticAlgorithm(graph, new MinimumVertexCover(),
                    new GeneticOperators(new RouletteStrategy(), new OnePointCrossoverStrategy(graph),
                        new BinaryTransformationStrategy(BinaryTransformationType.RandomBitFlip)),
                    new GeneticAlgorithmSettings(400, 50, 0.5f, 0.3f)),
                new GeneticAlgorithm(graph, new MinimumVertexCover(),
                    new GeneticOperators(new RouletteStrategy(), new OnePointCrossoverStrategy(graph),
                        new BinaryTransformationStrategy(BinaryTransformationType.RandomBitFlip)),
                    new GeneticAlgorithmSettings(400, 50, 0.5f, 0.3f, true))
            };
            foreach (Algorithm algh in alghs)
            {
                algh.LaunchAlgorithm();
                algh.ProgressReportChanged.Subscribe(
                    report =>
                        Console.WriteLine("[ALGH[{0}]]Current: {1} @ cost of {2} was accepted: {3}",
                            (algh as Algorithm).Id.ToString().Substring(0, 5), report.CurrentSolution.Count,
                            report.ProcessorTime, report.Accepted),
                    () =>
                        Console.WriteLine(
                            $"Algorithm {algh.GetType().Name} [{algh.Id}] has ended up with solution of: {algh.Problem.CurrentOutcome}"));
            }

            //PersistAlgorithmsOnCompletion(alghs);
        }

        //private static void PersistAlgorithmsOnCompletion(List<Algorithm> alghs)
        //{
        //    foreach (IAlgorithm algh in alghs)
        //    {
        //        algh.ProgressReportChanged.Subscribe(r => { }, () =>
        //        {
        //            var operation = new AddAlgorithm(algh);
        //            operation.Execute();
        //        });
        //    }
        //}
    }
}
