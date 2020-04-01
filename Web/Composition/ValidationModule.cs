using Autofac;
using ContactManagement.Infrastructure.Services;
using Microsoft.Extensions.Configuration;

namespace ContactManagement.Web.Composition
{
    public class ValidationModule : CompositionModule
    {
        private static readonly string ValidatorEndName = "Validator";
        public ValidationModule(IConfiguration configuration) : base(configuration) { }
        protected override void Register(ContainerBuilder builder)
        {
            //RegisterValidators<SampleService>(builder);
            builder.RegisterGeneric(typeof(ValidationService<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }

        private void RegisterValidators<T>(ContainerBuilder builder) where T : class
        {
            //RegisterByEndName<T>(builder, ValidatorEndName);
        }

    }
}
