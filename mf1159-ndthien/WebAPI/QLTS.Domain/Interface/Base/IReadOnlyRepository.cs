using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Domain
{
    public interface IReadOnlyRepository<TEntity>
    {
        /// <summary>
        /// Lấy tất cả entity
        /// </summary>
        /// <returns>Danh sách entity</returns>
        /// Author: NDThien 16/07/2023
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Lấy thông tin một entity
        /// </summary>
        /// <param name="id">Định danh entity</param>
        /// <returns>Thông tin một entity</returns>
        /// Author: NDThien 16/07/2023
        Task<TEntity> GetAsync(Guid id);

        /// <summary>
        /// Tìm xem entity có tồn tại
        /// </summary>
        /// <param name="id">Mã định danh entity</param>
        /// <returns>
        /// Tài sản tồn tại: Trả về thông tin entity
        /// Tài sản không tồn tại: Trả về null
        /// </returns>
        Task<TEntity?> FindAsync(Guid id);
    }
}
