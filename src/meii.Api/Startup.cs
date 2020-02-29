using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using meii.infrastrutucture.Context;
using FluentValidation.AspNetCore;
using meii.Api.Data;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using meii.Business.Services;
using meii.Business.Interfaces;
using meii.infrastrutucture.Repository;
using meii.Business.Entities.Notificacoes;
using AutoMapper;

namespace meii.Api
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

            services.AddAuthentication();

            //Conexão base Meii
            services.AddDbContext<MEContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("MEConnection")));

            //Conexão base Identity
            services.AddDbContext<AuthContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("AuthConnection")));

            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<INotificador, Notificador>();

            // Configuracao Identity Server
            services.AddIdentityCore<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AuthContext>()
            .AddDefaultTokenProviders();

            services.AddAutoMapper((serviceProvider, automapper) =>
            {
                automapper.AllowNullCollections = true;
               // automapper.UseEntityFrameworkCoreModel<GmContext>(serviceProvider);
            }, typeof(Startup).Assembly);

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "https://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = true;
            });

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Development");
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
