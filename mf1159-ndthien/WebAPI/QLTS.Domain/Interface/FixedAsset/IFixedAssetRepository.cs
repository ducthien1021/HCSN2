using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Domain
{
    public interface IFixedAssetRepository : IBaseRepository<FixedAsset>
    {
        /// <summary>
        /// Lấy mã code lớn nhất
        /// </summary>
        /// <param></param>
        /// <returns>Mã code lớn nhất</returns>
        /// Author: NDThien 22/07/2023
        Task<string> GetMaxCodeAsync();

        /// <summary>
        /// Tìm xem tài sản có tồn tại
        /// </summary>
        /// <param name="id">Mã code tài sản</param>
        /// <returns>
        /// Tài sản tồn tại: Trả về thông tin tài sản
        /// Tài sản không tồn tại: Trả về null
        /// </returns>
        /// Author: NDThien 22/07/2023
        Task<FixedAsset?> FindFixedAssetByCodeAsync(string code);

        /// <summary>
        /// Lấy tổng số lượng bản ghi
        /// </summary>
        /// <returns>Tổng số lượng bản ghi</returns>
        /// Author: NDThien 22/07/2023
        Task<int> GetTotalRecordsAsync();

        /// <summary>
        /// Lấy danh sách bản ghi theo điều kiện paging và filter
        /// </summary>
        /// <param name="page_size">Tổng số bản ghi trên một trang</param>
        /// <param name="paze_index">Trang hiện tại</param>
        /// <param name="filter">Điều kiện lọc</param>
        /// <returns>Danh sách tài sản được paging và filtered</returns>
        /// Author: NDThien 27/07/2023
        Task<IEnumerable<FixedAsset>> GetPagingRecordsAsync(int papeSize, int pageIndex, string? filter);


    }
}
