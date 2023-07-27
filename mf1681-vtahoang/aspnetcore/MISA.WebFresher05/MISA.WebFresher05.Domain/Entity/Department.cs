namespace MISA.WebFresher05.Domain
{
    public class Department
    {
        /// <summary>
        /// Id của phòng ban
        /// </summary>
        /// Created by: vtahoang(13/07/2023)
        public Guid department_id { get; set; }

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

        /// <summary>
        /// Trường xoá mềm
        /// </summary>
        /// Created by: vtahoang(13/07/2023)
        public byte? is_deleted { get; set; }
    }
}
