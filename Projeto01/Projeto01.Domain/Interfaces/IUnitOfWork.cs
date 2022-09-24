using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Interfaces
{
    /// <summary>
    /// Interface para unidade de trabalho do repositório
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        #region Repositórios

        public IContatoRepository ContatoRepository { get; }

        #endregion
    }
}
