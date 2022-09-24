using MongoDB.Driver;
using Projeto01.Infra.Cache.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Cache.MongoDB.Contexts
{
    /// <summary>
    /// Classe para conexão com o banco de dados do MongoDB
    /// </summary>
    public class MongoDBContext
    {
        private readonly MongoDBSettings? _mongoDBSettings;
        private IMongoDatabase _mongoDatabase;

        public MongoDBContext(MongoDBSettings? mongoDBSettings)
        {
            _mongoDBSettings = mongoDBSettings;

            #region Conectando no banco de dados

            var client = MongoClientSettings.FromUrl(new MongoUrl(_mongoDBSettings.Host));

            if(_mongoDBSettings.IsSSL)
            {
                client.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };
            }

            _mongoDatabase = new MongoClient(client).GetDatabase(_mongoDBSettings.Name);

            #endregion
        }

        /// <summary>
        /// Mapeando um documento / collection para gravação no MongoDB
        /// </summary>
        public IMongoCollection<ContatosModel> Contatos
            => _mongoDatabase.GetCollection<ContatosModel>("Contatos");
    }
}
