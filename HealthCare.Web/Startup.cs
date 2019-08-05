using HealthCare.Business.Implementations;
using HealthCare.Business.Interfaces;
using HealthCare.Data;
using HealthCare.Data.DataContext;
using HealthCare.Data.Models;
using HealthCare.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCare.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<HealthCareContext>(item => item.UseSqlServer(Configuration.GetConnectionString("HealthCareDb")));

            InitializeDependencyInjection(services);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private void InitializeDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IPatientSystem, PatientSystem>();

            services.AddScoped<IRepository<Patient>, Repository<Patient>>();
            services.AddScoped<IRepository<PatientVisit>, Repository<PatientVisit>>();
            services.AddScoped<IRepository<Visit>, Repository<Visit>>();
            services.AddScoped<IRepository<PatientVisitStatus>, Repository<PatientVisitStatus>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
