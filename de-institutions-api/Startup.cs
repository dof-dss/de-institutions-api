using de_institutions_infrastructure.Data;
using de_institutions_infrastructure.Features.Institution.Validation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Steeltoe.CloudFoundry.Connector.MySql.EFCore;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using System;
using System.Reflection;

namespace de_institutions_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        protected CloudFoundryServicesOptions CloudFoundryServicesOptions;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCloudFoundryOptions(Configuration);
            CloudFoundryServicesOptions = Configuration.GetSection("vcap").Get<CloudFoundryServicesOptions>();



            services.AddApiVersioning(
            options =>
            {
                // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });


            // de-institutions-api-mysql

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "NI school institutions API",
                    Description = "A simple api for Northern Ireland schools and institutions.",
                    Contact = new OpenApiContact
                    {
                        Name = "Michael Stevenson",
                        Email = "Michael.Stevenson@finance-ni.gov.uk",
                        Url = new Uri("https://www.micstevenson.co.uk/"),
                    }
                });

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer",
                //    BearerFormat = "JWT",
                //    In = ParameterLocation.Header,
                //    Description = "JWT Authorization header using the Bearer scheme."
                //});

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                // {
                //     {
                //           new OpenApiSecurityScheme
                //             {
                //                 Reference = new OpenApiReference
                //                 {
                //                     Type = ReferenceType.SecurityScheme,
                //                     Id = "Bearer"
                //                 }
                //             },
                //             new string[] {}
                //     }
                // });

            });

            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetAllInstitutionsQueryValidator>());

            // Add database
            services.AddDbContext<InstituitonContext>(options => options.UseMySql(Configuration));

            services.AddAutoMapper(typeof(Startup).GetTypeInfo().Assembly, typeof(InstituitonContext).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly, typeof(InstituitonContext).GetTypeInfo().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Run migrations
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var institutionContext = serviceScope.ServiceProvider.GetService<InstituitonContext>();
                institutionContext.Database.Migrate();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
