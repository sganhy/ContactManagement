using Autofac;
using ContactManagement.Web.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using Microsoft.OpenApi.Models;
using ContactManagement.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ContactManagement.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o =>
            {
                o.Filters.Add<DataNotFoundExceptionFilter>();
                o.Filters.Add<ValidationExceptionFilter>();
            });

            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.AllowTrailingCommas = true;
                o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                o.JsonSerializerOptions.IgnoreNullValues = true;
                o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            }
            ).AddMvcOptions(o =>
            {
                o.AddCustomInputFormatters();
                o.AddCustomOutputFormatters<SystemTextJsonOutputFormatter>();
            }); ;

            //Handle versioning through http header
            services.AddApiVersioning(o => o.ApiVersionReader = new HeaderApiVersionReader("api-version"));
            services.AddHttpClient();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact Management API", Version = "v1" }));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterCompositionModules(Configuration);
        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                    .UseSwagger()
                    .UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact Management API");
                        c.RoutePrefix = string.Empty;
                    });
            }

            app.UseAuthentication()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}