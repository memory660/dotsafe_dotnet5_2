using Com.Core.Dotsafe.Domain;
using Com.Core.Dotsafe.Infrastructure.Data;
using Com.Core.Dotsafe.Infrastructure.Repositories;
using Com.Core.Dotsafe.UI.ExtensionsMethods;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Core.Dotsafe.UI
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

            services.AddDbContext<DotsafesContext>(options =>
            {
                options.UseMySql(this.Configuration.GetConnectionString("MariaDbConnectionString"), ServerVersion.AutoDetect(this.Configuration.GetConnectionString("MariaDbConnectionString")));
            });

            services.AddInjections();
            services.AddCustomSecurity(this.Configuration); // cors, jwt
            services.AddControllers();

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                // règles   
                //options.Password.RequiredLength = 8;
                //options.SignIn.RequireConfirmedEmail = true;
                //
                //
            }).AddEntityFrameworkStores<DotsafesContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Com.Core.Dotsafe.UI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Com.Core.Dotsafe.UI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(SecurityMethods.DEFAULT_POLICY);  //
            app.UseAuthentication(); //

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
