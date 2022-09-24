using Projeto01.Infra.Cache.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Cache.MongoDB.Interfaces
{
    /// <summary>
    /// Interface para definir as operações da collection Contatos no MongoDB
    /// </summary>
    public interface IContatosPersistence
    {
        void Create(ContatosModel model);
        void Update(ContatosModel model);
        void Delete(ContatosModel model);

        List<ContatosModel> GetAll(int page, int limit);
        ContatosModel GetById(Guid idContato);
    }
}
