using Microsoft.AspNetCore.Mvc;
using QLTS.API.Controllers.Base;
using QLTS.Application;
using QLTS.Application.Dto.Department;

namespace QLTS.API.Controllers.Department
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<DepartmentDto, DepartmentCreateDto, DepartmentUpdateDto>
    {
        public DepartmentController(IDepartmentService departmentService) : base(departmentService)
        {
        }
    }
}
