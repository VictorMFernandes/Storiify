using Storiify.Api.Extensoes;
using Storiify.Api.Middlewares;
using Storiify.Compartilhado.Extensoes;
using Storiify.Dominio.Enums;
using Storiify.Dominio.Servicos;
using Storiify.Infra.BancoDeDados.Contexto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Storiify.Dominio.Sistema;
using Newtonsoft.Json;

namespace Storiify.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        private readonly string _nomeAplicacao;
        private readonly string _versao;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _nomeAplicacao = Configuration
                            .GetSection(EConfigSecao.NomeAplicacao.EnumTextos().Nome)
                            .Value;
            _versao = Configuration
                      .GetSection(EConfigSecao.Versao.EnumTextos().Nome)
                      .Value;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Configuracoes.ConnString = Configuration.GetConnectionString(EConfigSecao.ConexaoBd.EnumTextos().Nome);
            services.AddDbContextPool<BancoContexto>(options =>
                options.UseSqlite(Configuracoes.ConnString)
            );

            services.AddMvc(config =>
            {
                var regra = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();

                config.Filters.Add(new AuthorizeFilter(regra));
            })
            .AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                        .GetBytes(Configuration.GetSection(EConfigSecao.TokenSecreto.EnumTextos().Nome).Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true,
                };
            });

            services.AddResponseCompression();

            services.ConfigurarIoC();

            services.AdicionarDocumentacaoSwagger(_nomeAplicacao, _versao);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ISemeadorBd semeadorBd)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint($"/swagger/{_versao}/swagger.json", $"{_nomeAplicacao} API {_versao}");
                x.RoutePrefix = string.Empty;
            });

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseMiddleware<ErroMiddleware>();
            app.UseResponseCompression();
            app.UseMvc();

            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<BancoContexto>();
                dbContext.Database.EnsureCreated();
            }

            semeadorBd.SemearBancoDeDados();
        }
    }
}
