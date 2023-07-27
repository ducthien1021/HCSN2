using Dapper;
using QLTS.Domain;
using QLTS.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Infrastructure
{
    public abstract class BaseRepository<TEntity> : BaseReadOnlyRepository<TEntity>, IBaseRepository<TEntity>
    {
        #region Fields
        private readonly IUnitOfWork _uow;
        #endregion

        #region Constructor
        protected BaseRepository(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Create one entity
        /// </summary>
        /// <param name="entity">entity object</param>
        /// <returns>Number of record changed</returns>
        /// Author: NDThien 19/07/2023
        public async Task<int> CreateAsync(TEntity entity)
        {
            var sql = $"proc_insert_{TableName}";
            var result = await _uow.Connection.ExecuteAsync(sql, entity, commandType: CommandType.StoredProcedure, transaction: _uow.Transaction);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Number of record changed</returns>
        public async Task<int> UpdateAsync(TEntity entity)
        {
            var sql = $"proc_update_{TableName}";
            var result = await _uow.Connection.ExecuteAsync(sql, entity, commandType: CommandType.StoredProcedure, transaction: _uow.Transaction);
            return result;
        }

        /// <summary>
        /// Delete one record
        /// </summary>
        /// <param name="id">Record id</param>
        /// <returns>Number of record changed</returns>
        /// Auhor: NDThien 19/07/2023
        public async Task<int> DeleteAsync(Guid id)
        {
            var sql = $"DELETE FROM {TableName} WHERE {TableId}= @id";
            var param = new DynamicParameters();
            param.Add("id", id);
            var result = await _uow.Connection.ExecuteAsync(sql, param, transaction: _uow.Transaction);
            return result;
        }

        /// <summary>
        /// Delete many record
        /// </summary>
        /// <param name="listId">List record id</param>
        /// <returns>Number of record changed</returns>
        /// Auhor: NDThien 19/07/2023
        public async Task<int> DeleteManyAsync(List<Guid> listId)
        {
            var sql = $"DELETE FROM {TableName} WHERE {TableId} IN @listId";
            var param = new DynamicParameters();
            param.Add("listId", listId.Select(x => x));
            var result = await _uow.Connection.ExecuteAsync(sql, param, transaction: _uow.Transaction);
            return result;
        } 
        #endregion
    }
}
