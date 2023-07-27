using Dapper;
using QLTS.Domain;
using QLTS.Domain.Interface;
using QLTS.Domain.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Infrastructure
{
    public abstract class BaseReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity>
    {
        #region Fields
        protected readonly IUnitOfWork _uow;
        #endregion

        #region Properties
        public virtual string TableName { get; protected set; } = typeof(TEntity).Name;
        public virtual string TableId { get; protected set; } = typeof(TEntity).Name + "_id";
        #endregion

        #region Constructors
        protected BaseReadOnlyRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy tất cả entity
        /// </summary>
        /// <returns>Danh sách entity</returns>
        /// Author: NDThien 16/07/2023
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {TableName}";
            var result = await _uow.Connection.QueryAsync<TEntity>(sql, transaction: _uow.Transaction);
            return result;
        }

        /// <summary>
        /// Lấy thông tin một entity
        /// </summary>
        /// <param name="id">Định danh entity</param>
        /// <returns>Thông tin một entity</returns>
        /// Author: NDThien 16/07/2023
        public async Task<TEntity> GetAsync(Guid id)
        {
            var entity = await FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(String.Format(ResourceVN.NotFound, TableName, id));
            }
            return entity;
        }

        // <summary>
        /// Tìm xem entity có tồn tại
        /// </summary>
        /// <param name="id">Mã định danh entity</param>
        /// <returns>
        /// Tài sản tồn tại: Trả về thông tin entity
        /// Tài sản không tồn tại: Trả về null
        /// </returns>
        public async Task<TEntity?> FindAsync(Guid id)
        {
            var sql = $"SELECT * FROM {TableName} WHERE {TableId} = @id";
            var param = new DynamicParameters();
            param.Add("id", id);
            var result = await _uow.Connection.QueryFirstOrDefaultAsync<TEntity>(sql, param, transaction: _uow.Transaction);
            return result;
        } 
        #endregion
    }
}
