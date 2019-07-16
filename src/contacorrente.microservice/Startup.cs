using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace contacorrente.microservice
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;
        public Startup(IHostingEnvironment environment)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));

            var builder = new ConfigurationBuilder()
              .SetBasePath(environment.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
              .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc();
            services.AddOptions();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.AddMvc();

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Microservice DDD",
                    Version = "v1",
                    Description = "Um microserviço para a operação envolvendo contas correntes.",
                    Contact = new Contact
                    {
                        Name = "Rodrigo Costa",
                        Email = "rodrigo.costa@gmail.com"
                    }
                });

                c.CustomSchemaIds((type) => type.FullName);

                
                c.CustomSchemaIds((Type currentClass) =>
                {
                    var returnedValue = currentClass.Name;

                    if (returnedValue.EndsWith("Dto", StringComparison.InvariantCultureIgnoreCase))
                    {
                        returnedValue = returnedValue.Replace("Dto", string.Empty, StringComparison.InvariantCultureIgnoreCase);
                    }

                    if (returnedValue.EndsWith("Request", StringComparison.InvariantCultureIgnoreCase))
                    {
                        returnedValue = returnedValue.Replace("Request", "PayloadEntrada", StringComparison.InvariantCultureIgnoreCase);
                    }

                    if (returnedValue.EndsWith("Response", StringComparison.InvariantCultureIgnoreCase))
                    {
                        returnedValue = returnedValue.Replace("Response", "PayloadSaida", StringComparison.InvariantCultureIgnoreCase);
                    }
                    return returnedValue;
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });


            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste DB Server");
                options.DisplayRequestDuration();
            });

            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
