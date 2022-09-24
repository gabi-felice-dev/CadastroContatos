using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Cache.MongoDB.Contexts
{
    /// <summary>
    /// Classe para capturar os parametros de configuração
    /// para acesso ao MongoDB
    /// </summary>
    public class MongoDBSettings
    {
        public string? Host { get; set; }
        public string? Name { get; set; }
        public bool IsSSL { get; set; }
    }
}
