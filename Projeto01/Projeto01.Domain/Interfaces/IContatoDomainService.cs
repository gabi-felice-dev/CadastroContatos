using Projeto01.Domain.Core.Interfaces;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Interfaces
{
    /// <summary>
    /// Interface de serviços de domínio para contato
    /// </summary>
    public interface IContatoDomainService : IDomainService<Contato, Guid>
    {

    }
}
