using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebApi.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DotNetCoreWebApi
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
          
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

          //  services.AddDbContext<MeasurementContext>(options => options.UseSqlServer(Configuration["DefaultConnection"]));
            
            services.AddDbContext<MeasurementContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("LabDb")));


            //services.AddDbContext<MeasurementContext>(options => options.UseSqlServer(Configuration[@"server=DESKTOP-JP06AIC\SQLEXPRES; database=:LabDb; trusted_connection=true"]));
            /*services.AddDbContext<MeasurementContext>(options =>
             options.UseSqlServer(
                 @"Data Source=DESKTOP-JP06AIC\PATRYKSQL; Database = New; Trusted_Connection = True",
          
            b =>b.UseRowNumberForPaging()));
            */
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
