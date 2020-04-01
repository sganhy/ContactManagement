using System.Linq;
using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;

namespace ContactManagement.Web.Extensions
{
    public static class RegistrationBuilderExtensions
    {
         public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle>
            SetSingletonLifeTime(
                this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> builder,
                string endName) => builder.Where(t => t.Name.EndsWith(endName)).SingleInstance();
  
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> SetScopedLifeTime(
            this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> builder, string endName)
                =>  builder.Where(t => t.Name.EndsWith(endName)).InstancePerLifetimeScope();

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle>
            SetTransientLifeTime(
                this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> builder,
                string endName)
                => builder.Where(t => t.Name.EndsWith(endName)).InstancePerDependency();

    }
}
