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
    /// Dados do comando de atualização de contatos
    /// </summary>
    public class ContatoUpdateCommand : IRequest<ContatoDto>
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }
}
