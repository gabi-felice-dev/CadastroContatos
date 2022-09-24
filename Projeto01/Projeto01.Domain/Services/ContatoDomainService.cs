using Projeto01.Domain.Entities;
using Projeto01.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Services
{
    /// <summary>
    /// Classe de serviço de domínio para a entidade Contato
    /// </summary>
    public class ContatoDomainService : IContatoDomainService
    {
        //atributo
        private readonly IUnitOfWork _unitOfWork;

        //construtor para injeção de dependência
        public ContatoDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Contato entity)
        {
            #region O email do contato deve ser único

            if (_unitOfWork.ContatoRepository.GetByEmail(entity.Email) != null)
                throw new ArgumentException("O email informado já está cadastrado, tente outro.");

            #endregion

            #region O telefone do contato deve ser único

            if (_unitOfWork.ContatoRepository.GetByTelefone(entity.Telefone) != null)
                throw new ArgumentException("O telefone informado já está cadastrado, tente outro.");

            #endregion

            await _unitOfWork.ContatoRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(Contato entity)
        {
            #region O contato deve existir no banco de dados

            if (await _unitOfWork.ContatoRepository.GetByIdAsync(entity.Id) == null)
                throw new ArgumentException("Contato não encontrado, verifique o ID informado.");

            #endregion

            #region O email atualizado não pode ser igual ao de outro contato

            var contatoByEmail = _unitOfWork.ContatoRepository.GetByEmail(entity.Email);
            if (contatoByEmail != null && !contatoByEmail.Id.Equals(entity.Id))
                throw new ArgumentException("O email informado já pertence a outro contato cadastrado.");

            #endregion

            #region O telefone atualizado não pode ser igual ao de outro contato

            var contatoByTelefone = _unitOfWork.ContatoRepository.GetByTelefone(entity.Telefone);
            if (contatoByTelefone != null && !contatoByTelefone.Id.Equals(entity.Id))
                throw new ArgumentException("O telefone informado já pertence a outro contato cadastrado.");

            #endregion

            await _unitOfWork.ContatoRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Contato entity)
        {
            #region O contato deve existir no banco de dados

            if (await _unitOfWork.ContatoRepository.GetByIdAsync(entity.Id) == null)
                throw new ArgumentException("Contato não encontrado, verifique o ID informado.");

            #endregion

            await _unitOfWork.ContatoRepository.DeleteAsync(entity);
        }

        public async Task<List<Contato>> GetAllAsync(int page, int limit)
        {
            #region O limite de paginação de contatos é de 250 registros

            if (limit > 250)
                throw new ArgumentException("Informe um limite de no máximo 250 registros.");

            #endregion

            return await _unitOfWork.ContatoRepository.GetAllAsync(page, limit);
        }

        public async Task<Contato> GetByIdAsync(Guid id)
            => await _unitOfWork.ContatoRepository.GetByIdAsync(id);

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
