using System;

namespace ContactManagement.ApplicationCore.Validations
{
    public class ValidationMessage
    {
        private ValidationMessage(string errorCode, ValidationLevel level, string message, string propertyName)
        {
            ErrorCode = errorCode;
            Level = level;
            Message = message ?? throw new ArgumentNullException(nameof(message));
            PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
        }

        public string ErrorCode { get; }

        public ValidationLevel Level { get; }

        public string Message { get; }

        public string PropertyName { get; }

        public static ValidationMessage Create(ValidationLevel level, string message,
            string errorCode = "", string propertyName = "")
        {
            return new ValidationMessage(errorCode, level, message, propertyName);
        }
    }
}
