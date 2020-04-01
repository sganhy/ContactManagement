using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using ContactManagement.ApplicationCore.Services;
using ContactManagement.ApplicationCore.Exceptions;
using ContactManagement.ApplicationCore.Validations;

namespace ContactManagement.Infrastructure.Services
{
    public class ValidationService<T> : IValidationService<T> where T : class
    {
        private readonly IEnumerable<IValidator<T>> _validators;

        public ValidationService(IValidator<T>[] validators)
        {
            if (!validators?.Any() ?? true)
                throw new ArgumentException(nameof(validators));
            
            // manage priorities later  ==>
            //_validators = validators.OrderBy(v => v.Priority);
        }

        public ValidationResult Validate(T validatee)
        {
            return ValidateAsync(validatee)
                           .Result;
        }

        public void ValidateAndThrowOnError(T validatee)
        {
            var result = Validate(validatee);

            if (result.HasErrors)
                throw new ValidationException(result);
        }

        public async ValueTask<ValidationResult> ValidateAsync(T validatee, CancellationToken cancellationToken = default)
        {
            var result = ValidationResult.Create();

            foreach (var validator in _validators)
            {
                var currentResult = await validator.ValidateAsync(validatee, cancellationToken);

                result = result.Merge(currentResult);
                if (result.HasErrors) break;
            }

            return result;
        }

        public async ValueTask ValidateAndThrowOnErrorAsync(T validatee, CancellationToken cancellationToken = default)
        {
            var result = await ValidateAsync(validatee, cancellationToken);
            if (result.HasErrors)
                throw new ValidationException(result);
        }

    }
}
