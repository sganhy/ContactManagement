using ContactManagement.ApplicationCore.Entities;
using ContactManagement.ApplicationCore.Validations;
using System;
using System.Runtime.Serialization;

namespace ContactManagement.ApplicationCore.Exceptions
{
    [Serializable]
    public class ValidationException : System.Exception
    {
        public ValidationException(ValidationResult result)
        {
            Result = result;
        }

        /// <summary>Initializes a new instance of the <see cref="ValidationException"></see> class.</summary>
        protected ValidationException()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ValidationException"></see> class with serialized data.</summary>
        /// <param name="info">
        ///     The <see cref="System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized
        ///     object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="System.Runtime.Serialization.StreamingContext"></see> that contains contextual
        ///     information about the source or destination.
        /// </param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="info">info</paramref> parameter is null.</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">
        ///     The class name is null or
        ///     <see cref="System.Exception.HResult"></see> is zero (0).
        /// </exception>
        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ValidationException"></see> class with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        protected ValidationException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationException"></see> class with a specified error message
        ///     and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference (Nothing in
        ///     Visual Basic) if no inner exception is specified.
        /// </param>
        protected ValidationException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public ValidationResult Result { get; }
    }
}
