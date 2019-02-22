using System;
using System.IO;
using AspNetCore.RouteAnalyzer;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftServerTechnicalTask.Domain.Abstractions;
using SoftServerTechnicalTask.Domain.Abstractions.ChildEntityRepositories;
using SoftServeTechnicalTask.Application.Validators;
using SoftServeTechnicalTask.Host.Extensions;
using SoftServeTechnicalTask.Persistence.DBContext;
using SoftServeTechnicalTask.Persistence.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace SoftServeTechnicalTask.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IBusinessRepository, BusinessRepository>();
            services.AddScoped<IFamilyRepository, FamilyRepository>();
            services.AddScoped<IOfferingRepository, OfferingRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "SoftServeTechnicalTask API", Version = "v1" });
            });
            services.ConfigureSwaggerGen(options =>
            {
                string xmlPath = Path.Combine(AppContext.BaseDirectory, $"SoftServeTechnicalTask.Application.xml");
                options.IncludeXmlComments(xmlPath);
            });

            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<OrganizationValidator>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var authOptions = new AuthOptions(Configuration);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "GitHub";
            })
            .AddCookie()
            .AddOAuth("GitHub", options => { authOptions.InitGithubOAuthOptions(options); });

            services.AddRouteAnalyzer();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SoftServeTechnicalTask API V1");
            });

            app.UseAuthentication();

            app.ConfigureExceptionHandler();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
