namespace Localwire.Graphinder.Core.Exceptions
{
    using System;

    /// <summary>
    /// Represents error that occured during <see cref="T:Localwire.Graphinder.Core.Algorithms.IAlgorithm"/> solution finding or initial set up.
    /// </summary>
    public class AlgorithmException : Exception
    {
        /// <summary>
        /// Operation which failed.
        /// </summary>
        public readonly string Operation;

        /// <summary>
        /// Reason of operation failure.
        /// </summary>
        public readonly string OperationExceptionReason;

        /// <summary>
        /// Iteration of algorithm on which failure occured.
        /// </summary>
        public readonly uint Iteration;

        /// <summary>
        /// Initializes a new instance of exception thrown during <see cref="T:Localwire.Graphinder.Core.Algorithms.IAlgorithm"/>
        /// solution finding or initial set up.
        /// </summary>
        /// <param name="operation">Operation which failed.</param>
        /// <param name="reason">Reason of operation failure.</param>
        /// <param name="iteration">Iteration of algorithm on which failure occured.</param>
        public AlgorithmException(string operation, string reason, uint iteration = 0) : base()
        {
            Operation = operation;
            OperationExceptionReason = reason;
            Iteration = iteration;
        }
    }
}
