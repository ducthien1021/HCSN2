using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Domain.Interface.FixedAsset
{
    public interface IFixedAssetManager
    {
        /// <summary>
        /// Kiểm tra tài sản đã tồn tại hay chưa
        /// </summary>
        /// <param name="code">Mã tài sản</param>
        /// <returns></returns>
        /// Author: NDThien 19/07/2023
        Task CheckFixedAssetExistByCode(string code);
    }
}
