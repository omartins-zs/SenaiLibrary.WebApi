using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SenaiLibrary.WebApi.Contexts;
using SenaiLibrary.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiLibrary.WebApi
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
            // Adiciona os servicos necessarios para
            services.AddControllers();

            // Se não existir uma instância na memória da aplicação, cria um novo Context
            services.AddScoped<LibraryContext, LibraryContext>();

            services.AddTransient<JogadorRepository, JogadorRepository>();

            services
              // Define a forma de autenticacao
              .AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = "JwtBearer";
                   options.DefaultChallengeScheme = "JwtBearer";
               })

                // Define os parametros de validacaoo do token
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Valida quem está solicitando
                        ValidateIssuer = true,
                        // Valida quem está recebendo
                        ValidateAudience = true,
                        // Define se o tempo de expiracao sera validado
                        ValidateLifetime = true,
                        // criptografia e valida~ção da chave de autenticacao
                        IssuerSigningKey = new
                    SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SenaiLibrary-chave-autenticacao")),
                        // Valida o tempo de expiracao do token
                        ClockSkew = TimeSpan.FromMinutes(30),
                        // Nome do issuer, de onde está vindo
                        ValidIssuer = "SenaiLibrary.WebApi",
                        // Nome do audience, para onde está indo
                        ValidAudience = "SenaiLibrary.WebApi"
                    };
                });


            // A cada solicitaçao uma nova instanciae criada
            services.AddTransient<JogoRepository, JogoRepository>();

            services.AddRazorPages();
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            // Habilita a autenticacao
            app.UseAuthentication();

            // Habilita a autorizacao
            app.UseAuthorization();

            // Mapear os Controllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
