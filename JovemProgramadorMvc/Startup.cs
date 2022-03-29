using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JovemProgramadorMvc.Data.Context;
using JovemProgramadorMvc.Data.Repositorio;
using JovemProgramadorMvc.Data.Repositorio.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JovemProgramadorMvc
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
            services.AddControllersWithViews();
            services.AddDbContext<BancoContexto>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                });
            });

            services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            //using (var context = serviceScope.ServiceProvider.GetRequiredService<BancoContexto>())
            //    context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
