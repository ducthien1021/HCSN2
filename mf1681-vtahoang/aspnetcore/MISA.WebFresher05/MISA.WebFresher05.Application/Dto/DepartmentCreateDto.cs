using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher05.Application
{
    public class DepartmentCreateDto
    {
        /// <summary>
        /// Mã code phòng ban 
        /// </summary>
        /// Created by: vtahoang(13/07/2023)
        public String? department_code { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// Created by: vtahoang(13/07/2023)
        public String? department_name { get; set; }
    }
}
