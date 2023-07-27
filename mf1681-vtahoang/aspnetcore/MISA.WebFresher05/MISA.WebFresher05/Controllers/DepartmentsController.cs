using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher05.Application;
using MySqlConnector;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.WebFresher05.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentsService;

        public DepartmentsController(IDepartmentService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        /// <summary>
        /// Lấy danh sách bộ phận sử dụng
        /// </summary>
        /// <returns>Danh sách bộ phận sử dụng</returns>
        /// Created by: vtahoang (12/07/2023)
        [HttpGet]
        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var result = await _departmentsService.GetAllAsync();

            return result;
        }

        /// <summary>
        /// Lấy bộ phận sử dụng theo id
        /// </summary>
        /// <param name="id">Id của bộ phận sử dụng cần lấy</param>
        /// <returns>Bộ phận tương ứng</returns>
        /// Created by: vtahoang (12/07/2023)
        [HttpGet("{id}")]
        public async Task<DepartmentDto> GetAsync(Guid id)
        {
            var result = await _departmentsService.GetAsync(id);

            return result;
        }

        /// <summary>
        /// Tạo bộ phận sử dụng mới
        /// </summary>
        /// Created by: vtahoang (12/07/2023)
        [HttpPost]
        public async Task Post([FromBody] DepartmentCreateDto department)
        {
            await _departmentsService.CreateAsync(department);
        }

        /// <summary>
        /// Sửa thông tin bộ phận sử dụng
        /// </summary>
        /// <param name="id">id bộ phận sử dụng</param>
        /// <param name="value">giá trị sửa</param>
        /// Created by: vtahoang (12/07/2023)
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] DepartmentUpdateDto department)
        {
            await _departmentsService.UpdateAsync(department);
        }

        /// <summary>
        /// Xoá bộ phận có id tương ứng
        /// </summary>
        /// <param name="id">id bộ phận xoá</param>
        /// Created by: vtahoang (12/07/2023)
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _departmentsService.DeleteAsync(id);
        }
    }
}
