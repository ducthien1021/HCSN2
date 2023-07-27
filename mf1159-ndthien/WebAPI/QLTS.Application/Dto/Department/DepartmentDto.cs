using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Application.Dto.Department
{
    public class DepartmentDto
    {
        /// <summary>
        /// Định danh của phòng ban
        /// </summary>
        [Required]
        public Guid department_id { get; set; }

        /// <summary>
        /// Mã của phòng ban
        /// </summary>
        [MaxLength(50)]
        public string? department_code { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        [MaxLength(255)]
        public string? department_name { get; set; }

        /// <summary>
        /// Mô tả của phòng ban
        /// </summary>
        [MaxLength(500)]
        public string department_description { get; set; }
    }
}
