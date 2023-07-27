using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Application
{
    public interface IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> : IReadOnlyService<TEntityDto>
    {
        /// <summary>
        /// Create one entity
        /// </summary>
        /// <param name="entityCreateDto">Entity Dto create</param>
        /// <returns>Number of record changed</returns>
        /// Author: NDThien 19/07/2023
        Task<int> CreateAsync(TEntityCreateDto entityCreateDto);

        /// <summary>
        /// Update one entity
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <param name="entityUpdateDto">Entity Dto update</param>
        /// <returns>Number of record changed</returns>
        /// Author: NDThien 19/07/2023
        Task<int> UpdateAsync(Guid id, TEntityUpdateDto entityUpdateDto);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Number of record changed</returns>
        /// Author: NDThien 19/07/2023
        Task<int> DeleteAsync(Guid id);

        /// <summary>
        /// Delete many entity
        /// </summary>
        /// <param name="listId">List Id entity</param>
        /// <returns>Number of record changed</returns>
        /// Author: NDThien 19/07/2023
        Task<int> DeleteManyAsync(List<Guid> listId);
    }
}
