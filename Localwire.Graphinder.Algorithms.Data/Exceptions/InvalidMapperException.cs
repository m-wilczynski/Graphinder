namespace Localwire.Graphinder.Algorithms.DataAccess.Exceptions
{
    using System;

    /// <summary>
    /// Exception thrown on invalid mapper used for certain entity/domain model
    /// </summary>
    internal class InvalidMapperException : Exception
    {
        /// <summary>
        /// Type of object that was attempted to be mapped
        /// </summary>
        public Type AttemptedType { get; }

        /// <summary>
        /// Type of object that was expected by mapper
        /// </summary>
        public Type ExpectedType { get; }

        /// <summary>
        /// Operation on which exception occured, ie. ToDomainModel or ToEntityModel
        /// </summary>
        public string Operation { get; }

        public InvalidMapperException(Type attemptedType, Type expectedType, string operation)
        {
            AttemptedType = attemptedType;
            ExpectedType = expectedType;
            Operation = operation;
        }
    }
}
