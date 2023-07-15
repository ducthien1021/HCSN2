using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher05.Application
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Lấy tất cả phòng ban
        /// </summary>
        /// <returns>Tất cả phòng ban</returns>
        /// Created by: vtahoang (14/07/2023)
        Task<IEnumerable<DepartmentDto>> GetAllAsync();

        /// <summary>
        /// Lấy phòng ban theo id
        /// </summary>
        /// <param name="id">Id phòng ban</param>
        /// <returns>Phòng ban</returns>
        /// Created by: vtahoang (14/07/2023)
        Task<DepartmentDto> GetAsync(Guid id);

        /// <summary>
        /// Tìm phòng ban theo id
        /// </summary>
        /// <param name="id">Id phòng ban</param>
        /// <returns>Phòng ban</returns>
        /// Created by: vtahoang (14/07/2023)
        Task<DepartmentDto?> FindAsync(Guid id);

        /// <summary>
        /// Thêm phòng ban
        /// </summary>
        /// <param name="entity">Phòng ban</param>
        /// <returns></returns>
        /// Created by: vtahoang (14/07/2023)
        Task CreateAsync(DepartmentCreateDto departmentCreateDto);

        /// <summary>
        /// Sửa phòng ban
        /// </summary>
        /// <param name="entity">Phòng ban cần sửa</param>
        /// <returns></returns>
        /// Created by: vtahoang (14/07/2023)
        Task UpdateAsync(DepartmentUpdateDto departmentUpdateDto);

        /// <summary>
        /// Xoá phòng ban
        /// </summary>
        /// <param name="id">Id phòng ban cần xoá</param>
        /// <returns></returns>
        /// Created by: vtahoang (14/07/2023)
        Task DeleteAsync(Guid id);
    }
}
