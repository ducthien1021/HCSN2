using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher05.Domain
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Lấy tất cả phòng ban
        /// </summary>
        /// <returns>Tất cả phòng ban</returns>
        /// Created by: vtahoang (14/07/2023)
        Task<IEnumerable<Department>> GetAllAsync();

        /// <summary>
        /// Lấy phòng ban theo id
        /// </summary>
        /// <param name="id">Id phòng ban</param>
        /// <returns>Phòng ban</returns>
        /// Created by: vtahoang (14/07/2023)
        Task<Department> GetAsync(Guid id);

        /// <summary>
        /// Tìm phòng ban theo id
        /// </summary>
        /// <param name="id">Id phòng ban</param>
        /// <returns>Phòng ban</returns>
        /// Created by: vtahoang (14/07/2023)
        Task<Department?> FindAsync(Guid id);

        /// <summary>
        /// Thêm phòng ban
        /// </summary>
        /// <param name="entity">Phòng ban</param>
        /// <returns></returns>
        /// Created by: vtahoang (14/07/2023)
        Task CreateAsync(Department entity);

        /// <summary>
        /// Sửa phòng ban
        /// </summary>
        /// <param name="entity">Phòng ban cần sửa</param>
        /// <returns></returns>
        /// Created by: vtahoang (14/07/2023)
        Task UpdateAsync(Department entity);

        /// <summary>
        /// Xoá phòng ban
        /// </summary>
        /// <param name="entity">Phòng ban cần xoá</param>
        /// <returns></returns>
        /// Created by: vtahoang (14/07/2023)
        Task DeleteAsync(Department entity);
    }
}
