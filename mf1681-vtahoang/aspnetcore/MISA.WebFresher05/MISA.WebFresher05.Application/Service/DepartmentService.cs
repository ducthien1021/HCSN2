using MISA.WebFresher05.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher05.Application
{
    public class DepartmentService : IDepartmentService
    {
        #region Field
        private readonly IDepartmentRepository _departmentReposioty;
        #endregion

        #region Constructor
        public DepartmentService(IDepartmentRepository departmentReposioty)
        {
            _departmentReposioty = departmentReposioty;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var departments = await _departmentReposioty.GetAllAsync();

            var departmentDtos = departments.Select(x => MapDepartmentToDepartmentDto(x));

            return departmentDtos;
        }
        public async Task<DepartmentDto> GetAsync(Guid id)
        {
            var department = await _departmentReposioty.GetAsync(id);

            var departmentDto = MapDepartmentToDepartmentDto(department);

            return departmentDto;
        }
        public async Task<DepartmentDto?> FindAsync(Guid id)
        {
            var department = await _departmentReposioty.GetAsync(id);

            if (department == null)
            {
                return null;
            }

            var departmentDto = MapDepartmentToDepartmentDto(department);

            return departmentDto;
        }
        public Task CreateAsync(DepartmentCreateDto departmentCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DepartmentUpdateDto departmentUpdateDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            var department = await _departmentReposioty.FindAsync(id) ?? throw new Exception("Không tìm thấy.");
            await _departmentReposioty.DeleteAsync(department);
        }

        private DepartmentDto MapDepartmentToDepartmentDto(Department department)
        {
            var departmentDto = new DepartmentDto()
            {
                department_id = department.department_id,
                department_code = department.department_code,
                department_name = department.department_name,
            };
            return departmentDto;
        }
        #endregion
    }
}
