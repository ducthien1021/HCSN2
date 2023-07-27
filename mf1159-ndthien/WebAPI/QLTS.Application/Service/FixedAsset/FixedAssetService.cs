using QLTS.Domain;
using QLTS.Domain.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using QLTS.Domain.Service;
using AutoMapper;
using QLTS.Domain.Interface.FixedAsset;
using QLTS.Application.Dto.Pagination;

namespace QLTS.Application
{
    public class FixedAssetService : BaseService<FixedAsset, FixedAssetDto, FixedAssetCreateDto, FixedAssetUpdateDto>, IFixedAssetService
    {
        #region Fields
        private readonly IFixedAssetRepository _fixedAssetRepository;
        private readonly IFixedAssetManager _fixedAssetManager;


        #endregion

        #region Constructors
        public FixedAssetService(IFixedAssetRepository fixedAssetRepository, IMapper mapper, IFixedAssetManager fixedAssetManager) : base(fixedAssetRepository, mapper)
        {
            _fixedAssetManager = fixedAssetManager;
            _fixedAssetRepository = fixedAssetRepository;
        }
        #endregion


        #region Methods

        /// <summary>
        /// Sinh code mới cho tài sản
        /// </summary>
        /// <returns>Mã code mới</returns>
        /// Author: NDThien 22/07/2023
        public async Task<string> GetNewCodeAsync()
        {
            var maxCode = await _fixedAssetRepository.GetMaxCodeAsync();
            if (maxCode != null)
            {
                maxCode = maxCode.Replace("TS", "");
            }
            long numberCode = 0;
            var newCode = "";
            if (Int64.TryParse(maxCode, out numberCode))
            {
                ++numberCode;
                newCode = numberCode.ToString().PadLeft(maxCode.Length, '0');
            }
            else
            {
                ++numberCode;
                newCode = numberCode.ToString().PadLeft(5, '0');
            }
            newCode = $"TS{newCode}";
            return newCode;
        }

        /// <summary>
        /// Lấy danh sách bản ghi theo điều kiện paging và filter
        /// </summary>
        /// <param name="page_size">Tổng số bản ghi trên một trang</param>
        /// <param name="paze_index">Trang hiện tại</param>
        /// <param name="filter">Điều kiện lọc</param>
        /// <returns>Danh sách tài sản được paging và filtered</returns>
        /// Author: NDThien 27/07/2023
        public async Task<IEnumerable<FixedAssetDto>> GetPagingRecordsAsync(int page_size, int page_index, List<FilterDto>? filter)
        {
            var filterQueryBuidler = "";
            filter?.ForEach(s =>
            {
                filterQueryBuidler = $"{s.filter_field} LIKE '%{s.value}%'";
            });

            var entities = await _fixedAssetRepository.GetPagingRecordsAsync(page_size, page_index, filterQueryBuidler);
            var entitiesDto = _mapper.Map<IEnumerable<FixedAssetDto>>(entities);
            return entitiesDto;
        }

        /// <summary>
        /// Lấy tổng số lượng bản ghi
        /// </summary>
        /// <returns>Tổng số lượng bản ghi</returns>
        /// Author: NDThien 22/07/2023
        public async Task<int> GetTotalRecordsAsync()
        {
            var totalRecords = await _fixedAssetRepository.GetTotalRecordsAsync();
            return totalRecords;
        }

        protected override async Task<FixedAsset> MapCreateDtoToEnity(FixedAssetCreateDto? entityCreateDto)
        {
            // Validate
            await _fixedAssetManager.CheckFixedAssetExistByCode(entityCreateDto.fixed_asset_code);
            var fixedAsset = _mapper.Map<FixedAsset>(entityCreateDto);
            return fixedAsset;
        }

        protected override async Task<FixedAsset> MapUpdateDtoToEnity(Guid id, FixedAssetUpdateDto? entityUpdateDto)
        {
            var fixedAsset = _mapper.Map<FixedAsset>(entityUpdateDto); 
            fixedAsset.fixed_asset_id = id;
            return fixedAsset;
        }
        #endregion

    }
}
