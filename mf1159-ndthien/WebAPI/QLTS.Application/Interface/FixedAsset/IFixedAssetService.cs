using QLTS.Application.Dto.Pagination;
using QLTS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Application
{
    public interface IFixedAssetService : IBaseService<FixedAssetDto, FixedAssetCreateDto, FixedAssetUpdateDto>
    {
        /// <summary>
        /// Sinh code mới cho tài sản
        /// </summary>
        /// <returns>Mã code mới</returns>
        /// Author: NDThien 22/07/2023
        Task<string> GetNewCodeAsync();

        /// <summary>
        /// Lấy danh sách bản ghi theo điều kiện paging và filter
        /// </summary>
        /// <param name="page_size">Tổng số bản ghi trên một trang</param>
        /// <param name="paze_index">Trang hiện tại</param>
        /// <param name="filter">Điều kiện lọc</param>
        /// <returns>Danh sách tài sản được paging và filtered</returns>
        /// Author: NDThien 27/07/2023
        Task<IEnumerable<FixedAssetDto>> GetPagingRecordsAsync(int page_size, int paze_index, List<FilterDto>? filter);

        /// <summary>
        /// Lấy tổng số lượng bản ghi
        /// </summary>
        /// <returns>Tổng số lượng bản ghi</returns>
        /// Author: NDThien 22/07/2023
        Task<int> GetTotalRecordsAsync();
    }
}

