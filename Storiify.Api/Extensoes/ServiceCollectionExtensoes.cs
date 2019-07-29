using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Storiify.Api.Documentacao.Exemplos;
using Storiify.Api.Documentacao.Filtros;
using Storiify.Compartilhado.Padroes;
using Storiify.Dominio.Gerenciadores;
using Storiify.Dominio.Repositorios;
using Storiify.Dominio.Servicos;
using Storiify.Infra.BancoDeDados.Contexto;
using Storiify.Infra.BancoDeDados.Repositorios;
using Storiify.Infra.BancoDeDados.Transacoes;
using Storiify.Infra.Servicos;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace Storiify.Api.Extensoes
{
    public static class ServiceCollectionExtensoes
    {
        public static void ConfigurarIoC(this IServiceCollection services)
        {
            // Gerais
            services.AddTransient<IUow, Uow>();
            services.AddTransient<ISemeadorBd, SemeadorBd>();
            // Gerenciadores
            services.AddTransient<UsuarioGerenciador, UsuarioGerenciador>();
            services.AddTransient<AutenticacaoGerenciador, AutenticacaoGerenciador>();

            services.AddTransient<HistoriaGerenciador, HistoriaGerenciador>();
            services.AddTransient<PersonagemGerenciador, PersonagemGerenciador>();

            services.AddTransient<FotoGerenciador, FotoGerenciador>();
            // Repositórios
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddTransient<ISerieHistoriasRepositorio, SerieHistoriasRepositorio>();
            services.AddTransient<IHistoriaRepositorio, HistoriaRepositorio>();
            services.AddTransient<IPersonagemRepositorio, PersonagemRepositorio>();
            // Serviços
            services.AddTransient<IEmailServico, EmailServico>();
            services.AddTransient<IFotoServico, FotoServico>();
        }

        public static IServiceCollection AdicionarDocumentacaoSwagger(this IServiceCollection services, string nomeAplicacao, string versao)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc(versao, new Info
                    {
                        Title = nomeAplicacao,
                        Version = versao,
                        Description = $"UsuarioId Padrão: {PadroesString.UsuarioId}\n" +
                                      $"HistoriaId Padrão: {PadroesString.Historia1Id}"
                    }
                );

                s.ExampleFilters();
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                s.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Autorização JWT usando o esquema Bearer. Exemplo: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                s.AddSecurityRequirement(security);
                s.OperationFilter<BadRequestFiltro>();
            });

            services.AddSwaggerExamplesFromAssemblyOf<RegistrarUsuarioComandoExemplo>();

            return services;
        }
    }
}
