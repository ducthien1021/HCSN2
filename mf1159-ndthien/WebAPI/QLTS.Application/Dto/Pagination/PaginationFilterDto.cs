using QLTS.Application.Dto.Pagination;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QLTS.Application.Dto.Pagination
{
    public class PaginationFilterDto
    {
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        [Required]
        public int page_size { get; set; }

        /// <summary>
        /// Trang hiện tại
        /// </summary>
        [Required]
        public int page_index { get; set; }
        
        /// <summary>
        /// Điều kiện filter
        /// </summary>
        public List<FilterDto>? filter { get; set; }
    }
}
