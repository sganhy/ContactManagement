using System.Threading;
using System.Threading.Tasks;

namespace ContactManagement.ApplicationCore.Validations
{
    public interface IValidator<in T> where T : class
    {
        ValidationResult Validate(T entity);

        ValueTask<ValidationResult> ValidateAsync(T entity, CancellationToken cancellationToken = default);
    }
}
