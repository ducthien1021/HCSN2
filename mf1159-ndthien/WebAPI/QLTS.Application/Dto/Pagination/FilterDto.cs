using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Application.Dto.Pagination
{
    public class FilterDto
    {
        /// <summary>
        /// Tên trường thông tin cần lọc
        /// </summary>
        public string filter_field { get; set; }

        /// <summary>
        /// Giá trị của trường thông tin lọc
        /// </summary>
        public string value { get; set; }
    }
}
