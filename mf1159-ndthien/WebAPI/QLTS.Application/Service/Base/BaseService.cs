using AutoMapper;
using QLTS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Application
{
    public abstract class BaseService<TEntity, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : BaseReadOnlyService<TEntity, TEntityDto>, IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto>
    {
        #region Fields
        protected readonly IBaseRepository<TEntity> _baseRepository;
        #endregion

        #region Constructors
        protected BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper) : base(baseRepository, mapper)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Create new record
        /// </summary>
        /// <param name="entityCreateDto">entity create dto </param>
        /// <returns>Number of record changed</returns>
        /// Author: NDThien 19/07/2023
        public virtual async Task<int> CreateAsync(TEntityCreateDto entityCreateDto)
        {
            // Validate tại hàm map
            var entity = await MapCreateDtoToEnity(entityCreateDto);
            // Insert
            var res = await _baseRepository.CreateAsync(entity);
            return res;
        }

        /// <summary>
        /// Update record entity
        /// </summary>
        /// <param name="id">record id</param>
        /// <param name="entityUpdateDto">entity update dto</param>
        /// <returns>Number of record changed</returns>
        /// Author: NDThien 19/07/2023
        public virtual async Task<int> UpdateAsync(Guid id, TEntityUpdateDto entityUpdateDto)
        {
            // Validate tại hàm map
            var entity = await MapUpdateDtoToEnity(id, entityUpdateDto);
            // Insert
            var res = await _baseRepository.UpdateAsync(entity);
            return res;
        }

        /// <summary>
        /// Delelte record
        /// </summary>
        /// <param name="id">Record id</param>
        /// <returns>Number of record changed</returns>
        /// Author: NDThien 19/07/2023
        public virtual async Task<int> DeleteAsync(Guid id)
        {
            // Check entity exist
            var entity = await _baseRepository.GetAsync(id);
            // Insert
            var result = await _baseRepository.DeleteAsync(id);
            return result;
        }

        /// <summary>
        /// Delelte many record
        /// </summary>
        /// <param name="listId">List record id</param>
        /// <returns>Number of record changed</returns>
        /// Author: NDThien 19/07/2023
        public virtual async Task<int> DeleteManyAsync(List<Guid> listId)
        {
            if(listId.Count == 0)
            {
                throw new Exception("Không được truyền danh sách rỗng");
            }
            var result = await _baseRepository.DeleteManyAsync(listId);
            return result;
        }

        protected abstract Task<TEntity> MapCreateDtoToEnity(TEntityCreateDto? entityCreateDto);
        protected abstract Task<TEntity> MapUpdateDtoToEnity(Guid id, TEntityUpdateDto? entityCreateDto); 
        #endregion
    }
}
