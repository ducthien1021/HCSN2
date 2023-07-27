using QLTS.Domain;
using QLTS.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Infrastructure
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        #region Properties
        public override string TableName { get; protected set; } = "department";
        public override string TableId { get; protected set; } = "department_id";
        #endregion

        #region Constructors
        public DepartmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        } 
        #endregion
    }
}
