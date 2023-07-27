using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Domain.Interface
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        #region Fields
        /// <summary>
        /// Mở connection tới database
        /// </summary>
        DbConnection Connection { get; }

        /// <summary>
        /// Mở transaction
        /// </summary>
        DbTransaction? Transaction { get; } 
        #endregion

        #region Methods
        /// <summary>
        /// Bắt đầu một transaction đồng bộ
        /// </summary>
        /// Author: NDThien 19/07/2023
        void BeginTransaction();

        /// <summary>
        /// Bắt đầu một transaction bất đồng bộ
        /// </summary>
        /// Author: NDThien 19/07/2023
        Task BeginTransactionAsync();

        /// <summary>
        /// Commit transaction đồng bộ
        /// </summary>
        /// Author: NDThien 19/07/2023
        void Commit();

        /// <summary>
        /// Commit transaction bất đồng bộ
        /// </summary>
        /// Author: NDThien 19/07/2023
        Task CommitAsync();

        /// <summary>
        /// Rollback transaction đồng bộ
        /// </summary>
        /// Author: NDThien 19/07/2023
        void Rollback();

        /// <summary>
        /// Rollback transaction bất đồng bộ
        /// </summary>
        /// Author: NDThien 19/07/2023
        Task RollbackAsync(); 
        #endregion

    }
}
