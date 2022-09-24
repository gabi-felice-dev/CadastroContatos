using FluentValidation.Results;
using Projeto01.Domain.Core.Interfaces;
using Projeto01.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Entities
{
    /// <summary>
    /// Entidade de domínio
    /// </summary>
    public class Contato : IEntity
    {
        public Guid Id { get; set; }        
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #region Atributos

        private string? _nome;
        private string? _email;
        private string? _telefone;

        #endregion

        #region Propriedades

        public string? Nome { get => _nome; set => _nome = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? Telefone { get => _telefone; set => _telefone = value; }

        public ValidationResult Validate => new ContatoValidator().Validate(this);

        #endregion
    }
}
