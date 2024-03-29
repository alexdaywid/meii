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
using meii.Business.Entities.Notificacoes;
using AutoMapper;
using Microsoft.OpenApi.Models;
using meii.infrastructure.Repository;
using System.Text.Json.Serialization;

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

            //Conex�o base Meii
            services.AddDbContext<MEContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("MEConnection")));

            //Conex�o base Identity
            services.AddDbContext<AuthContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("AuthConnection")));

           
            // Configuracao Identity Server
            services.AddIdentityCore<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddSignInManager<SignInManager<IdentityUser>>()
            .AddUserManager<UserManager<IdentityUser>>()
            .AddEntityFrameworkStores<AuthContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication().AddIdentityCookies();

            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<INotificador, Notificador>();

            services.AddAutoMapper((serviceProvider, automapper) =>
            {
                automapper.AllowNullCollections = true;
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

            // Configurando o servi�o de documenta��o do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Comparador de Fundos - Meuportfol.io",
                        Version = "v1",
                        Description = "Comparador de Fundos - Meuportfol.io. Para utiliza��o nos procure para obter credencial",
                        Contact = new OpenApiContact
                        {
                            Name = "Alex",
                        }
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

            // Habilitar o middleware para servir o Swagger gerado como um endpoint JSON
            app.UseSwagger();

            // Habilitar o middleware para servir o swagger-ui (HTML, JS, CSS, etc.), 
            // Especificando o Endpoint JSON Swagger.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AMeii - Auxiliando o Micro-Empres�rio.");
                
            });

            app.UseCors("Development");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
