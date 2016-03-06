namespace Localwire.Graphinder.Core.Exceptions
{
    using System;

    /// <summary>
    /// Represents error that occured during <see cref="T:Localwire.Graphinder.Core.Problems.IProblem"/> solution finding or initial set up.
    /// </summary>
    public class ProblemException : Exception
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
        /// Initializes a new instance of exception thrown during <see cref="T:Localwire.Graphinder.Core.Problems.IProblem"/> based operation.
        /// </summary>
        /// <param name="operation">Operation which failed.</param>
        /// <param name="reason">Reason of operation failure.</param>
        public ProblemException(string operation, string reason) : base()
        {
            Operation = operation;
            OperationExceptionReason = reason;
        }
    }
}
