using MySqlConnector;
using QLTS.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Infrastructure.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly DbConnection _connection;

        private DbTransaction? _transaction = null;
        #endregion

        #region Constructor
        public UnitOfWork(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Hàm get connection
        /// </summary>
        /// Author: NDThien 19/07/2023
        public DbConnection Connection => _connection;

        /// <summary>
        /// Hàm get transaction
        /// </summary>
        /// Author: NDThien 19/07/2023
        public DbTransaction? Transaction => _transaction;

        /// <summary>
        /// Bắt đầu một transaction
        /// </summary>
        /// Author: NDThien 19/07/2023
        public void BeginTransaction()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _transaction = _connection.BeginTransaction();
            }
            else
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction();
            }
        }

        /// <summary>
        /// Bắt đầu một transaction bất đồng bộ
        /// </summary>
        /// Author: NDThien 19/07/2023
        public async Task BeginTransactionAsync()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _transaction = await _connection.BeginTransactionAsync();
            }
            else
            {
                _connection.OpenAsync(); // Mở 
                _transaction = await _connection.BeginTransactionAsync();
            }
        }

        /// <summary>
        /// Thực hiện commit transaction
        /// </summary>
        /// Author: NDThien 19/07/2023
        public void Commit()
        {
            _transaction?.Commit();
            Dispose();
        }

        /// <summary>
        /// Thực hiện commit bất đồng bộ transaction
        /// </summary>
        /// Author: NDThien 19/07/2023
        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
            await DisposeAsync();
        }

        /// <summary>
        /// Thực hiện rollback transaction
        /// </summary>
        /// Author: NDThien 19/07/2023
        public void Rollback()
        {
            _transaction?.Rollback();
            Dispose();
        }

        /// <summary>
        /// Thực hiện rollback bất đồng bộ transaction
        /// </summary>
        /// Author: NDThien 19/07/2023
        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
            await DisposeAsync();
        }

        /// <summary>
        /// Thực hiện dispose transaction
        /// </summary>
        /// Author: NDThien 19/07/2023
        public void Dispose()
        {
            _transaction.Dispose();
            _transaction = null;
            _connection.Close(); // Đóng
        }

        /// <summary>
        /// Thực hiện dispose bất đồng bộ transaction
        /// </summary>
        /// Author: NDThien 19/07/2023
        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }
            _transaction = null;
            await _connection.CloseAsync(); // Đóng
        } 
        #endregion
    }
}
