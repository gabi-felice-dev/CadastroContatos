using MongoDB.Driver;
using Projeto01.Infra.Cache.MongoDB.Contexts;
using Projeto01.Infra.Cache.MongoDB.Interfaces;
using Projeto01.Infra.Cache.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Cache.MongoDB.Persistence
{
    public class ContatosPersistence : IContatosPersistence
    {
        //atributo
        private readonly MongoDBContext _mongoDBContext;

        //injeção de dependência
        public ContatosPersistence(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public void Create(ContatosModel model)
        {
            _mongoDBContext.Contatos.InsertOne(model);
        }

        public void Update(ContatosModel model)
        {
            var filter = Builders<ContatosModel>.Filter.Eq(c => c.Id, model.Id);
            _mongoDBContext.Contatos.ReplaceOne(filter, model);
        }

        public void Delete(ContatosModel model)
        {
            var filter = Builders<ContatosModel>.Filter.Eq(c => c.Id, model.Id);
            _mongoDBContext.Contatos.DeleteOne(filter);
        }

        public List<ContatosModel> GetAll(int page, int limit)
        {
            var filter = Builders<ContatosModel>.Filter.Where(c => true);
            return _mongoDBContext.Contatos
                .Find(filter)
                .Skip(page)
                .Limit(limit)
                .ToList();
        }

        public ContatosModel GetById(Guid idContato)
        {
            var filter = Builders<ContatosModel>.Filter.Eq(c => c.Id, idContato);
            return _mongoDBContext.Contatos
                .Find(filter)
                .FirstOrDefault();
        }
    }
}
