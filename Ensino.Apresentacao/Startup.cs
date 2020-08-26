using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ensino.Infraestrutura.IoC;
using Ensino.Aplicacao;
using AutoMapper;
using Ensino.Infraestrutura.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using Ensino.Apresentacao.Models;

namespace Ensino.Apresentacao
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<IConfiguration>(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .Build());

            services.Configure<Information>(Configuration.GetSection("Information"));

            services.AddDbContext<ContextoDB>(o => o.UseSqlServer(Configuration.GetConnectionString("EnsinoSqlServerBase_Con"), x => x.MigrationsAssembly("Ensino.Apresentacao")));
            InjetorDependencias.Registrar(services);
            services.AddAutoMapper(x => x.AddProfile(new MappingEntidade()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                             .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore); ;
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Professor}/{action=Index}/{id?}");
            });
        }
    }
}
