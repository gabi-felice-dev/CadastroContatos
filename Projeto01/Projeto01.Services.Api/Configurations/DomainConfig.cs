using Projeto01.Domain.Interfaces;
using Projeto01.Domain.Services;

namespace Projeto01.Services.Api.Configurations
{
    /// <summary>
    /// Classe para configuração de injeção de dependencia dos componentes
    /// da camada de domínio do sistema.
    /// </summary>
    public static class DomainConfig
    {
        public static void AddDomainConfig(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IContatoDomainService, ContatoDomainService>();
        }
    }
}
