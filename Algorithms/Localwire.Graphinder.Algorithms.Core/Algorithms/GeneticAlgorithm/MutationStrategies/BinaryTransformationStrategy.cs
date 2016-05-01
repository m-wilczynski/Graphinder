namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.MutationStrategies
{
    using System;
    using Helpers.Operations.Binary;

    /// <summary>
    /// Represents mutation strategy that transforms binary encoded individual.
    /// </summary>
    public class BinaryTransformationStrategy : IMutationStrategy
    {
        private BinaryTransformationType _transformationType;
        private Action<bool[]> _binaryTransformation;

        /// <summary>
        /// Instantiates binary transformation strategy used by <see cref="T:Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.GeneticAlgorithm"/> mutation.
        /// </summary>
        /// <param name="transformationType"></param>
        public BinaryTransformationStrategy(BinaryTransformationType transformationType = BinaryTransformationType.RandomBitFlip)
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

        /// <summary>
        /// Mutate given encoded individual.
        /// </summary>
        /// <param name="individual">Individual to mutate.</param>
        public void Mutate(Individual individual)
        {
            if (individual == null)
                throw new ArgumentException(nameof(individual));
            _binaryTransformation(individual.CurrentSolution);
        }
    }
}
