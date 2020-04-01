using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;
using Microsoft.Extensions.Configuration;
using ContactManagement.Web.Extensions;

namespace ContactManagement.Web.Composition
{
    public abstract class CompositionModule : Module
    {
        public IConfiguration Configuration { get ; }
        public CompositionModule(IConfiguration configure) => Configuration = configure;
        protected abstract void Register(ContainerBuilder builder);
        protected override void Load(ContainerBuilder builder) => Register(builder);
        protected virtual IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> ScanAndRegister<T>(ContainerBuilder builder) where T : class
            =>  builder.RegisterAssemblyTypes(typeof(T).Assembly)
                .Where(type => !type.IsAbstract && type.IsPublic)
                .AsImplementedInterfaces();

        protected void RegisterByEndName<T>(ContainerBuilder builder, string endName,
            RegistrationLifeTime lifeTime = RegistrationLifeTime.Transient) where T : class
        {
            switch (lifeTime)
            {
                case RegistrationLifeTime.Transient:
                    ScanAndRegister<T>(builder).SetTransientLifeTime(endName);
                    break; 
                case RegistrationLifeTime.Singleton:
                    ScanAndRegister<T>(builder).SetSingletonLifeTime(endName);
                    break;
                case RegistrationLifeTime.Scoped:
                    ScanAndRegister<T>(builder).SetScopedLifeTime(endName);
                    break;
            }
        }

    }
}
