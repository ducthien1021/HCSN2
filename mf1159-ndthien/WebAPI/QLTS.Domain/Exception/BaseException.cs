using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QLTS.Domain
{
    public class BaseException
    {
        #region Fields
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Message dành cho dev
        /// </summary>
        public string? DevMessage { get; set; }

        /// <summary>
        /// Message dành cho user
        /// </summary>
        public string? UserMessage { get; set; }

        /// <summary>
        /// TraceId
        /// </summary>
        public string? TraceId { get; set; }

        /// <summary>
        /// MoreInfo
        /// </summary>
        public string? MoreInfo { get; set; }

        /// <summary>
        /// Errors
        /// </summary>
        public Object? Errors { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Override lại hàm toString của class
        /// </summary>
        /// <returns></returns>
        /// Author: NDThien 19/07/2023
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        } 
        #endregion
    }
}
