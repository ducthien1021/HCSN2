using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Domain
{
    public interface IBaseRepository<TEntity> : IReadOnlyRepository<TEntity>
    {
        /// <summary>
        /// Thêm mới entity
        /// </summary>
        /// <param name="entity">Entity thêm mới</param>
        /// <returns>Số bản ghi thay đổi</returns>
        Task<int> CreateAsync(TEntity entity);

        /// <summary>
        /// Sửa entity
        /// </summary>
        /// <param name="entity">entity sửa</param>
        /// <returns>Số bản ghi thay đổi</returns>
        Task<int> UpdateAsync(TEntity entity);

        /// <summary>
        /// Xóa entity
        /// </summary>
        /// <param name="id">Định danh entity</param>
        /// <returns>Số bản ghi thay đổi</returns>
        Task<int> DeleteAsync(Guid id);

        /// <summary>
        /// Delete many record
        /// </summary>
        /// <param name="listId">List record id</param>
        /// <returns>Number of record changed</returns>
        /// Auhor: NDThien 19/07/2023
        Task<int> DeleteManyAsync(List<Guid> listId);
    }
}
