using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Core.Interfaces
{
    /// <summary>
    /// Modelo de interface para entidades de domínio
    /// </summary>
    public interface IEntity : IValidator
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
