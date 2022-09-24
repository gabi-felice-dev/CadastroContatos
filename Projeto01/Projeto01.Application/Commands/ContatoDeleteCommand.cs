using MediatR;
using Projeto01.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Commands
{
    /// <summary>
    /// Dados do comando de exclusão de contatos
    /// </summary>
    public class ContatoDeleteCommand : IRequest<ContatoDto>
    {
        public Guid Id { get; set; }
    }
}
