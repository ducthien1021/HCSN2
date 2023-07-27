using Microsoft.AspNetCore.Mvc;
using QLTS.Application;

namespace QLTS.API.Controllers.Base
{
    public abstract class BaseController<TEnityDto, TEnityCreateDto, TEnityUpdateDto> : BaseReadOnlyController<TEnityDto>
    {
        #region Fields
        private readonly IBaseService<TEnityDto, TEnityCreateDto, TEnityUpdateDto> _baseService;
        #endregion

        #region Constructors
        protected BaseController(IBaseService<TEnityDto, TEnityCreateDto, TEnityUpdateDto> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Thêm bản ghi
        /// </summary>
        /// <param name="enityCreateDto">Bản ghi thêm mới</param>
        /// createdby: ndthien 19/07/2023
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TEnityCreateDto enityCreateDto)
        {
            var result = await _baseService.CreateAsync(enityCreateDto);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        /// <param name="value">Thông tin cập nhật của tài sản</param>
        /// createdby: ndthien 12/07/2023
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TEnityUpdateDto enityUpdateDto)
        {
            var result = await _baseService.UpdateAsync(id, enityUpdateDto);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi</param>
        /// createdby: ndthien 12/07/2023
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _baseService.DeleteAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        /// <param name="id">ID của bản ghi</param>
        /// createdby: ndthien 12/07/2023
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] List<Guid> listId)
        {
            var result = await _baseService.DeleteManyAsync(listId);
            return Ok(result);
        } 
        #endregion
    }
}
