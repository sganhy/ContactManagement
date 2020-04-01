using System.Linq;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.Configuration;
using Module = Autofac.Module;

namespace ContactManagement.Web.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterCompositionModules(this ContainerBuilder builder, IConfiguration configuration)
        {
            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => !t.IsAbstract && t.Name.EndsWith("Module") && t.IsAssignableTo<Module>());

            foreach (var type in types)
            {
                var constructor = type.GetConstructor(new[] { typeof(IConfiguration) });
                if (constructor != null)  
                    builder.RegisterModule((Module)constructor.Invoke(new object[] { configuration }));
               
            }
        }
    }
}
