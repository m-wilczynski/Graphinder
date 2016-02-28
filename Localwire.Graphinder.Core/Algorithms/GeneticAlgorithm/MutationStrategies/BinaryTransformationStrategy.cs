namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.MutationStrategies
{
    using System;
    using Helpers.Operations.Binary;

    /// <summary>
    /// Class representing mutation strategy that transforms binary encoded individual.
    /// </summary>
    public class BinaryTransformationStrategy : IMutationStrategy
    {
        private BinaryTransformationType _transformationType;
        private Action<bool[]> _binaryTransformation;

        public BinaryTransformationStrategy(BinaryTransformationType transformationType)
        {
            TransformationType = transformationType;
            //Enforce setting transformation action in case of transformationType = 0;
            //TODO: Make _transformationType nullable?
            _binaryTransformation = BinaryTransformation.Request(_transformationType);
        }

        //TODO: Extract binary transformations as interface and move down to IMutationStrategy?
        /// <summary>
        /// Type of binary transformation on which mutation is based.
        /// </summary>
        public BinaryTransformationType TransformationType
        {
            get { return _transformationType; }
            set
            {
                if (value != _transformationType)
                {
                    _transformationType = value;
                    _binaryTransformation = BinaryTransformation.Request(_transformationType);
                }
            }
        }

        public void Mutate(Individual individual)
        {
            if (individual == null)
                throw new ArgumentException(nameof(individual));
            _binaryTransformation(individual.CurrentSolution);
        }
    }
}
