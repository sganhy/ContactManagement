using System.Collections.Generic;
using Autofac;
using AutoMapper;
using ContactManagement.Web.Mappings;
using Microsoft.Extensions.Configuration;

namespace ContactManagement.Web.Composition
{
    public class AutoMapperModule : CompositionModule
    {
        public AutoMapperModule(IConfiguration configuration) : base(configuration) { }

        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ContactMappingProfile).Assembly)
                .Where(type => type.IsSubclassOf(typeof(Profile)) && type.IsPublic && !type.IsAbstract)
                .As<Profile>();

            //register your configuration as a single instance
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                //add your profiles (either resolve from container or however else you acquire them)
                foreach (var profile in c.Resolve<IEnumerable<Profile>>()) cfg.AddProfile(profile);
            })).AsSelf()
                .SingleInstance();

            //register your mapper
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
