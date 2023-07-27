using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTS.Domain.Interface;
using QLTS.Domain.Interface.FixedAsset;
using QLTS.Domain.Resource;

namespace QLTS.Domain.Service.FixedAsset
{
    public class FixedAssetManager : IFixedAssetManager
    {
        #region Fields
        private readonly IFixedAssetRepository _fixedAssetRepository;
        #endregion

        #region Constructors
        public FixedAssetManager(IFixedAssetRepository fixedAssetRepository)
        {
            _fixedAssetRepository = fixedAssetRepository;
        }
        #endregion

        #region Methods
        // <summary>
        /// Kiểm tra tài sản đã tồn tại hay chưa
        /// </summary>
        /// <param name="code">Mã tài sản</param>
        /// <returns></returns>
        /// Author: NDThien 19/07/2023
        public async Task CheckFixedAssetExistByCode(string code)
        {
            var fixedAsset = await _fixedAssetRepository.FindFixedAssetByCodeAsync(code);
            if (fixedAsset != null)
            {
                throw new ConflictException(String.Format(ResourceVN.ErrorAssetCodeExist, code));
            }
        }
        #endregion
    }
}
