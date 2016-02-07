namespace Localwire.Graphinder.Core.Helpers.Operations.Binary
{
    using System;

    /// <summary>
    /// Class representing binary transformations on bits arrays.
    /// </summary>
    public class BinaryTransformation
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Flip random bit in array
        /// </summary>
        /// <param name="array">Bits array.</param>
        public void RandomBitFlip(bool[] array)
        {
            var randomIndex = _random.Next(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                if (i == randomIndex)
                {
                    array[i] = !array[i];
                    return;
                }
            }
        }

        /// <summary>
        /// Flip all array bits.
        /// </summary>
        /// <param name="array">Bits array.</param>
        public void AllBitFlip(bool[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = !array[i];
        }

        /// <summary>
        /// Request action for given transformation type.
        /// </summary>
        /// <param name="transformation">Transformation type.</param>
        /// <returns>Transformation action.</returns>
        public static Action<bool[]> Request(BinaryTransformationType transformation)
        {
            switch (transformation)
            {
                case BinaryTransformationType.RandomBitFlip:
                    return new BinaryTransformation().RandomBitFlip;
                case BinaryTransformationType.AllBitFlip:
                    return new BinaryTransformation().AllBitFlip;
                default:
                    return new BinaryTransformation().RandomBitFlip;
            }
        }
    }

    public enum BinaryTransformationType
    {
        RandomBitFlip,
        AllBitFlip,
    }
}
