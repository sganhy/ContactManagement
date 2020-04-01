using ContactManagement.ApplicationCore.Validations;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManagement.ApplicationCore.Services
{
    public interface IValidationService<in T> where T : class
    {
        ValidationResult Validate(T validatee);
        void ValidateAndThrowOnError(T validatee);
        ValueTask<ValidationResult> ValidateAsync(T validatee, CancellationToken cancellationToken = default);
        ValueTask ValidateAndThrowOnErrorAsync(T validatee, CancellationToken cancellationToken = default);
    }
}
