using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Data.SqlServer.Configurations
{
    /// <summary>
    /// Mapeamento ORM da entidade Contato
    /// </summary>
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasIndex(c => c.Email).IsUnique();
            builder.HasIndex(c => c.Telefone).IsUnique();
        }
    }
}
