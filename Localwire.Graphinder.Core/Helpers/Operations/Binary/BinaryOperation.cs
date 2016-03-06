namespace Localwire.Graphinder.Core.Helpers.Operations.Binary
{
    using System;

    /// <summary>
    /// Represents binary operations on bits arrays.
    /// </summary>
    public class BinaryOperation
    {
        /// <summary>
        /// Performss OR operation on two bits arrays.
        /// </summary>
        /// <param name="left">Left bits array.</param>
        /// <param name="right">Right bits array.</param>
        /// <returns>Bits array representing OR operation outcome.</returns>
        public bool[] Or(bool[] left, bool[] right)
        {
            var length = left.Length >= right.Length ? left.Length : right.Length;
            bool[] output = new bool[length];

            for (int i = 0; i < length; i++)
            {
                var el1 = i < left.Length ? left[i] : false;
                var el2 = i < right.Length ? right[i] : false;
                output[i] = el1 | el2;
            }
            return output;
        }

        /// <summary>
        /// Performs AND operation on two bits arrays.
        /// </summary>
        /// <param name="left">Left bits array.</param>
        /// <param name="right">Right bits array.</param>
        /// <returns>Bits array representing AND operation outcome.</returns>
        public bool[] And(bool[] left, bool[] right)
        {
            var length = left.Length >= right.Length ? left.Length : right.Length;
            bool[] output = new bool[length];

            for (int i = 0; i < length; i++)
            {
                var el1 = i < left.Length ? left[i] : false;
                var el2 = i < right.Length ? right[i] : false;
                output[i] = el1 & el2;
            }
            return output;
        }

        /// <summary>
        /// Requests function for given operation type.
        /// </summary>
        /// <param name="operation">Operation type.</param>
        /// <returns>Operation function.</returns>
        public static Func<bool[], bool[], bool[]> Request(BinaryOperationType operation)
        {
            switch (operation)
            {
                case BinaryOperationType.And:
                    return new BinaryOperation().And;
                case BinaryOperationType.Or:
                    return new BinaryOperation().Or;
                default:
                    return new BinaryOperation().Or;
            }
        }
    }

    public enum BinaryOperationType
    {
        Or,
        And
    }
}
