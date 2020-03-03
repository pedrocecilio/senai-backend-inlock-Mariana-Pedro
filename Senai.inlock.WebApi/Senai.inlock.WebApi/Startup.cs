using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Senai.inlock.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            services
    // Define a forma de autenticação
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "JwtBearer";
        options.DefaultChallengeScheme = "JwtBearer";
    })

    // Define os parâmetros de validação do token
    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Quem está solicitando
            ValidateIssuer = true,

            // Quem está validando
            ValidateAudience = true,

            // Definindo o tempo de expiração
            ValidateLifetime = true,

            // Forma de criptografia
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("InLock-autenticacao")),

            // Tempo de expiração do token
            ClockSkew = TimeSpan.FromMinutes(15),

            // Nome da issuer, de onde está vindo
            ValidIssuer = "Senai.inlock.WebApi",

            // Nome da audience, de onde está vindo
            ValidAudience = "Senai.inlock.WebApi"
        };
    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Habilita o uso de autenticação
            app.UseAuthentication();

            //Define a utilização do MVC.
            app.UseMvc();
        }
    }
}
