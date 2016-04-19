namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Algorithms
{
    using System;
    using Core.Algorithms;
    using Entities.Algorithms;
    using Entities.Algorithms.GeneticAlgorithm;
    using Entities.Algorithms.SimulatedAnnealing;
    using Exceptions;
    using GeneticAlgorithm;
    using SimulatedAnnealing;
    
    internal static class GenericAlgorithmMappingResolver
    {
        public static IAlgorithm AsDomainModelResolved(this AlgorithmEntity entity)
        {
            if (entity is GeneticAlgorithmEntity)
                return ((GeneticAlgorithmEntity) entity).AsDomainModel();
            if (entity is SimulatedAnnealingEntity)
                return ((SimulatedAnnealingEntity) entity).AsDomainModel();

            throw new MappingNotImplementedException(entity);
        }

        public static AlgorithmEntity AsEntityModelResolved(this IAlgorithm model)
        {
            if (model is Core.Algorithms.GeneticAlgorithm.GeneticAlgorithm)
                return ((Core.Algorithms.GeneticAlgorithm.GeneticAlgorithm) model).AsEntityModel();
            if (model is Core.Algorithms.SimulatedAnnealing.SimulatedAnnealing)
                return ((Core.Algorithms.SimulatedAnnealing.SimulatedAnnealing) model).AsEntityModel();

            throw new MappingNotImplementedException(model as Algorithm);
        }
    }
}
