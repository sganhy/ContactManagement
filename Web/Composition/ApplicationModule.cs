using Autofac;
using ContactManagement.Infrastructure.Services;
using Microsoft.Extensions.Configuration;

namespace ContactManagement.Web.Composition
{
    public class ApplicationModule : CompositionModule
    {
        public ApplicationModule(IConfiguration configuration) : base(configuration) {}
        protected override void Register(ContainerBuilder builder)
        {
            ScanAndRegister<ContactService>(builder);
        }

    }
}
