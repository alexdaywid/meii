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
using meii.Api.Extensions;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICartaoFidelidadeRepository, CartaoFidelidadeRepository>();
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

            // Cors politica de restrição de origem
            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                    {
                        builder
                        .WithOrigins("http://localhost:4200", "https://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            //JWT
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.ValidoEm,
                    ValidIssuer = appSettings.Emissor,
                };
            });

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Comparador de Fundos - Meuportfol.io",
                        Version = "v1",
                        Description = "Comparador de Fundos - Meuportfol.io. Para utilização nos procure para obter credencial",
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
            else
            {
                app.UseHsts(); //habilita uso https
            }

            // Habilitar o middleware para servir o Swagger gerado como um endpoint JSON
            app.UseSwagger();

            // Habilitar o middleware para servir o swagger-ui (HTML, JS, CSS, etc.), 
            // Especificando o Endpoint JSON Swagger.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AMeii - Auxiliando o Micro-Empresário.");
                
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
