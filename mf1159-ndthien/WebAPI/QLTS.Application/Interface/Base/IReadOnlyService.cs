using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Application
{
    public interface IReadOnlyService<TEntityDto>
    {
        /// <summary>
        /// Get list entity
        /// </summary>
        /// <returns>List entity</returns>
        /// Author: NDThien 19/07/2023
        Task<IEnumerable<TEntityDto>> GetAllAsync();

        /// <summary>
        /// Get info entity
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity object</returns>
        /// Author: NDThien 19/07/2023
        Task<TEntityDto> GetAsync(Guid id);
    }
}
