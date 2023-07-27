using QLTS.Application.Dto.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Application
{
    public interface IDepartmentService:IBaseService<DepartmentDto, DepartmentCreateDto, DepartmentUpdateDto>
    {

    }
}
