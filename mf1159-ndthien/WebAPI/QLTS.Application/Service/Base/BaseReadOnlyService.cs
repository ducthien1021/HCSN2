using QLTS.Domain.Resource;
using QLTS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace QLTS.Application
{
    public abstract class BaseReadOnlyService<TEntity, TEntityDto> : IReadOnlyService<TEntityDto>
    {
        #region Fields
        protected readonly IReadOnlyRepository<TEntity> _readOnlyRepository;
        protected readonly IMapper _mapper;
        #endregion

        #region Constructors
        protected BaseReadOnlyService(IReadOnlyRepository<TEntity> readOnlyRepository, IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get list entity
        /// </summary>
        /// <returns>List entity</returns>
        /// Author: NDThien 19/07/2023
        public async Task<IEnumerable<TEntityDto>> GetAllAsync()
        {
            var entities = await _readOnlyRepository.GetAllAsync();
            var entitiesDto = _mapper.Map<IEnumerable<TEntityDto>>(entities);
            return entitiesDto;
        }

        /// <summary>
        /// Get info entity
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity object</returns>
        /// Author: NDThien 19/07/2023
        public async Task<TEntityDto> GetAsync(Guid id)
        {
            var entity = await _readOnlyRepository.GetAsync(id);
            var entityDto = _mapper.Map<TEntityDto>(entity);
            return entityDto;
        } 
        #endregion
    }
}
