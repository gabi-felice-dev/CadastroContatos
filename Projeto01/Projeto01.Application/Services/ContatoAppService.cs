using MediatR;
using Projeto01.Application.Commands;
using Projeto01.Application.Interfaces;
using Projeto01.Application.Models;
using Projeto01.Domain.Entities;
using Projeto01.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Services
{
    public class ContatoAppService : IContatoAppService
    {
        //atributo
        private readonly IMediator _mediator;

        //construtor para injeção de dependência
        public ContatoAppService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ContatoDto> Create(ContatoCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<ContatoDto> Update(ContatoUpdateCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<ContatoDto> Delete(ContatoDeleteCommand command)
        {
            return await _mediator.Send(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
