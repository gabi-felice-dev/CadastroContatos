using MediatR;
using Projeto01.Application.Interfaces;
using Projeto01.Application.Services;

namespace Projeto01.Services.Api.Configurations
{
    /// <summary>
    /// Classe para configuração de injeção de dependencia dos componentes
    /// da camada de aplicação do sistema.
    /// </summary>
    public static class ApplicationConfig
    {
        public static void AddApplicationConfig(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IContatoAppService, ContatoAppService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
