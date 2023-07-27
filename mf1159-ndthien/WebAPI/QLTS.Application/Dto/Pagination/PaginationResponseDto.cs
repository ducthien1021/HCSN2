using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Application.Dto.Pagination
{
    public class PaginationResponseDto
    {
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int total_records { get; set; }

        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int total_page { get; set;}

        /// <summary>
        /// Danh sách tài sản khi lấy dữ liệu phân trang và lọc
        /// </summary>
        public IEnumerable<FixedAssetDto>? data { get; set; } 
    }
}
