using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using QLTS.API.Controllers.Base;
using QLTS.Application;
using QLTS.Application.Dto.Pagination;

namespace QLTS.API.Controllers.FixedAsset
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FixedAssetsController : BaseController<FixedAssetDto, FixedAssetCreateDto, FixedAssetUpdateDto>
    {
        private readonly IFixedAssetService _fixedAssetService;
        public FixedAssetsController(IFixedAssetService fixedAssetService) : base(fixedAssetService)
        {
            _fixedAssetService = fixedAssetService;
        }


        /// <summary>
        /// Lấy mã code mới
        /// </summary>
        /// <returns></returns>
        /// createdby: ndthien 19/07/2023
        [HttpGet("new-code")]
        public async Task<IActionResult> GetNewCode()
        {
            var newCode = await _fixedAssetService.GetNewCodeAsync();
            return Ok(newCode);
        }

        /// <summary>
        /// Lấy danh sách bản ghi theo điều kiện paging và filter
        /// </summary>
        /// <returns></returns>
        /// createdby: ndthien 27/07/2023
        [HttpPost("paging-filter")]
        public async Task<IActionResult> PagingFilterFixedAsset([FromBody] PaginationFilterDto paginationFilterDto)
        {
            var page_size = paginationFilterDto.page_size;
            var page_index = paginationFilterDto.page_index;
            var filter = paginationFilterDto.filter;
            var data = await _fixedAssetService.GetPagingRecordsAsync(page_size, page_index, filter);
            var total_records = await _fixedAssetService.GetTotalRecordsAsync();
            var total_page = (double)total_records / page_size;
            var result = new PaginationResponseDto()
            {
                total_records = total_records,
                total_page = (int)Math.Ceiling(total_page),
                data = data
            };
            return Ok(result);
        }

    }
}
