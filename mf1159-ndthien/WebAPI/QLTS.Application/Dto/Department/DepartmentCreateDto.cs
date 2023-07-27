using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Application.Dto.Department
{
    public class DepartmentCreateDto
    {
        /// <summary>
        /// Mã của phòng ban
        /// </summary>
        public string department_code { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string department_name { get; set; }

        /// <summary>
        /// Mô tả của phòng ban
        /// </summary>
        public string department_description { get; set; }
    }
}
