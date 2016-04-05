namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.Setup
{
    public enum CrossoverStrategyType
    {
        None,
        OnePointCrossoverStrategy
    }

    public enum MutationStrategyType
    {
        None,
        BinaryTransformationStrategy
    }

    public enum SelectionStrategyType
    {
        None,
        RouletteStrategy
    }
}
