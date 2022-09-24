using Microsoft.EntityFrameworkCore;
using Projeto01.Domain.Entities;
using Projeto01.Domain.Interfaces;
using Projeto01.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Data.SqlServer.Repositories
{
    /// <summary>
    /// Classe de repositório para a entidade Contato
    /// </summary>
    public class ContatoRepository : BaseRepository<Contato, Guid>, IContatoRepository
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        //construtor para injeção de dependência
        public ContatoRepository(SqlServerContext sqlServerContext) : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public Contato GetByEmail(string email)
            => _sqlServerContext.Contatos
                .AsNoTracking()
                .FirstOrDefault(c => c.Email.Equals(email));

        public Contato GetByTelefone(string telefone)
            => _sqlServerContext.Contatos
                .AsNoTracking()
                .FirstOrDefault(c => c.Telefone.Equals(telefone));
    }
}
