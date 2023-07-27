using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLTS.Application;

namespace QLTS.API.Controllers.Base
{
    public class BaseReadOnlyController<TEntityDto> : ControllerBase
    {
        #region Fields
        private readonly IReadOnlyService<TEntityDto> _readOnlyService;
        #endregion

        #region Constructors
        public BaseReadOnlyController(IReadOnlyService<TEntityDto> readOnlyService)
        {
            _readOnlyService = readOnlyService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy danh sách bản ghi
        /// </summary>
        /// <returns></returns>
        /// createdby: ndthien 19/07/2023
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entitiesDto = await _readOnlyService.GetAllAsync();
            return Ok(entitiesDto);
        }

        /// <summary>
        /// Lấy thông tin một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi</param>
        /// <returns></returns>
        /// createdby: ndthien 19/07/2023
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entityDto = await _readOnlyService.GetAsync(id);
            return Ok(entityDto);
        } 
        #endregion

    }
}
