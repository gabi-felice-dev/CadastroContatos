using AutoMapper;
using FluentValidation;
using MediatR;
using Projeto01.Application.Commands;
using Projeto01.Application.Models;
using Projeto01.Domain.Entities;
using Projeto01.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.RequestHandlers
{
    /// <summary>
    /// Componente do MediatR para processamento dos COMMANDS (CREATE, UPDATE e DELETE)
    /// </summary>
    public class ContatoRequestHandler : IDisposable,
        IRequestHandler<ContatoCreateCommand, ContatoDto>,
        IRequestHandler<ContatoUpdateCommand, ContatoDto>,  
        IRequestHandler<ContatoDeleteCommand, ContatoDto>
    {
        #region Injeção de dependência

        private readonly IContatoDomainService _contatoDomainService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContatoRequestHandler(IContatoDomainService contatoDomainService, IMediator mediator, IMapper mapper)
        {
            _contatoDomainService = contatoDomainService;
            _mediator = mediator;
            _mapper = mapper;
        }

        #endregion

        public async Task<ContatoDto> Handle(ContatoCreateCommand request, CancellationToken cancellationToken)
        {
            //Capturar os dados do contato
            var contato = _mapper.Map<Contato>(request);

            //Executando a validação da entidade
            if (!contato.Validate.IsValid)
                throw new ValidationException(contato.Validate.Errors);
                        
            await _contatoDomainService.CreateAsync(contato);
            return _mapper.Map<ContatoDto>(contato);
        }

        public async Task<ContatoDto> Handle(ContatoUpdateCommand request, CancellationToken cancellationToken)
        {
            //Capturar os dados do contato
            var contato = _mapper.Map<Contato>(request);

            //Executando a validação da entidade
            if (!contato.Validate.IsValid)
                throw new ValidationException(contato.Validate.Errors);

            await _contatoDomainService.UpdateAsync(contato);
            return _mapper.Map<ContatoDto>(contato);
        }

        public async Task<ContatoDto> Handle(ContatoDeleteCommand request, CancellationToken cancellationToken)
        {
            var contato = await _contatoDomainService.GetByIdAsync(request.Id);

            await _contatoDomainService.DeleteAsync(contato);
            return _mapper.Map<ContatoDto>(contato);
        }

        public void Dispose()
        {
            _contatoDomainService.Dispose();
        }
    }
}
