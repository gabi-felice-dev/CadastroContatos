using Microsoft.EntityFrameworkCore;
using Projeto01.Domain.Entities;
using Projeto01.Infra.Data.SqlServer.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Data.SqlServer.Contexts
{
    /// <summary>
    /// Classe de contexto do EntityFramework para o SqlServer
    /// </summary>
    public class SqlServerContext : DbContext
    {
        //construtor -> ctor + 2x[tab]
        public SqlServerContext(DbContextOptions<SqlServerContext> dbContextOptions)
            : base(dbContextOptions) //construtor da superclasse (DbContext)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoConfiguration());
        }

        public DbSet<Contato>? Contatos { get; set; }
    }
}
