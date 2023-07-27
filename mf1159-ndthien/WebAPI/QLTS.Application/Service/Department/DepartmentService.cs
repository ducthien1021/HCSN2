using AutoMapper;
using QLTS.Application.Dto.Department;
using QLTS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Application
{
    public class DepartmentService : BaseService<Department, DepartmentDto, DepartmentCreateDto, DepartmentUpdateDto>, IDepartmentService
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructors
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper) : base(departmentRepository, mapper)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion

        #region Methods
        protected override Task<Department> MapCreateDtoToEnity(DepartmentCreateDto? entityCreateDto)
        {
            throw new NotImplementedException();
        }

        protected override Task<Department> MapUpdateDtoToEnity(Guid id, DepartmentUpdateDto? entityCreateDto)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
