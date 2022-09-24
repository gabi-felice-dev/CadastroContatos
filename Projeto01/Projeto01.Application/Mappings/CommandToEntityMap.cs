using AutoMapper;
using Projeto01.Application.Commands;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Mappings
{
    /// <summary>
    /// Classe de mapeamento de objetos COMMAND para => ENTITY
    /// </summary>
    public class CommandToEntityMap : Profile
    {
        public CommandToEntityMap()
        {
            CreateMap<ContatoCreateCommand, Contato>()
                .AfterMap((command, entity) => 
                { 
                    entity.Id = Guid.NewGuid();
                    entity.CreatedAt = DateTime.Now;
                    entity.UpdatedAt = DateTime.Now;
                });

            CreateMap<ContatoUpdateCommand, Contato>()
                .AfterMap((command, entity) =>
                {
                    entity.UpdatedAt = DateTime.Now;
                });

        }
    }
}
