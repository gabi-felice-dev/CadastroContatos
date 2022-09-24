using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Projeto01.Domain.Core.Interfaces
{
    /// <summary>
    /// Modelo de interface para aplicar regras de validação
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Método para retornar o resultado de uma validação
        /// </summary>
        ValidationResult Validate { get; }
    }
}
