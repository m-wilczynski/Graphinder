namespace Localwire.Graphinder.Core.Exceptions
{
    using System;

    /// <summary>
    /// Represents error that occured upon attempt to modify already locked for modifiactions data structure.
    /// </summary>
    public class DataStructureLockedException : Exception
    {
        /// <summary>
        /// Type of data structure that threw exception.
        /// </summary>
        public readonly Type DataStructureType;

        /// <summary>
        /// Reason of operation failure.
        /// </summary>
        public readonly string OperationExceptionReason;

        /// <summary>
        /// Initializes a new instance of exception thrown upon attempt to modify locked data structure.
        /// </summary>
        public DataStructureLockedException(string operation, Type dataStructureType)
        {
            OperationExceptionReason = operation;
            DataStructureType = dataStructureType;
        }
    }
}
