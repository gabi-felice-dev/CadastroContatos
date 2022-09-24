using AutoMapper;
using Projeto01.Application.Models;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Mappings
{
    /// <summary>
    /// Classe de mapeamento de objetos ENTITY para => MODEL
    /// </summary>
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Contato, ContatoDto>();
        }
    }
}
