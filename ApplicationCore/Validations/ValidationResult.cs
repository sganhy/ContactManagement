using ContactManagement.ApplicationCore.Exceptions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ContactManagement.ApplicationCore.Validations
{
    public class ValidationResult
    {
        private readonly List<ValidationMessage> _validationMessages = new List<ValidationMessage>();

        private ValidationResult()
        {
        }

        private ValidationResult(IEnumerable<ValidationMessage> messages) => _validationMessages.AddRange(messages);

        public bool HasErrors => _validationMessages.Any(m => m.Level == ValidationLevel.Error);
        public bool HasMessages => _validationMessages.Any();
        public IList<ValidationMessage> Messages => new ReadOnlyCollection<ValidationMessage>(_validationMessages);
        public string WarningsAsSingleString => BuildMessageByLevel(ValidationLevel.Warning);
        public string ErrorsAsSingleString => BuildMessageByLevel(ValidationLevel.Error);
        public static ValidationResult Create() => new ValidationResult();

        private string BuildMessageByLevel(ValidationLevel level)
        {
            var sv = new StringBuilder();
            foreach (var message in _validationMessages.Where(vm => vm.Level == level))
                sv.AppendLine(message.Message);
            return sv.ToString();
        }

        public void AddWarning(string message, string property = "", string errorCode = "")
        {
            Add(message, property, ValidationLevel.Warning, errorCode);
        }

        public void AddError(string message, string property = "", string errorCode = "")
        {
            Add(message, property, ValidationLevel.Error, errorCode);
        }

        public ValidationResult Merge(ValidationResult result)
        {
            var messages = new List<ValidationMessage>();
            messages.AddRange(Messages);

            if (result != null)
                messages.AddRange(result.Messages);

            return new ValidationResult(messages);
        }

        private void Add(string message, string property, ValidationLevel level, string errorCode = "")
        {
            var validationMessage = ValidationMessage.Create(level, message, errorCode, property);

            _validationMessages.Add(validationMessage);
        }

        public static void ThrowError(string property, string message, string errorCode = "")
        {
            var validationResult = new ValidationResult();
            validationResult.AddError(message, property, errorCode);
            throw new ValidationException(validationResult);
        }
    }

}
