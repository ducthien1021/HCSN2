using QLTS.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Application
{
    public class FixedAssetDto
    {
        /// <summary>
        /// Id tài sản
        /// </summary>
        [Required]
        public Guid fixed_asset_id { get; set; }

        /// <summary>
        /// Mã tài sản
        /// </summary>
        [MaxLength(50)]
        public string? fixed_asset_code { get; set; }

        /// <summary>
        /// Tên tài sản
        /// </summary>
        [MaxLength(255)]
        public string? fixed_asset_name { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        public Guid? department_id { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [MaxLength(50)]
        public string? department_code { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        [MaxLength(255)]
        public string? department_name { get; set; }

        /// <summary>
        /// Id loại tài sản
        /// </summary>
        public Guid? fixed_asset_category_id { get; set; }

        /// <summary>
        /// Mã loại tài sản
        /// </summary>
        [MaxLength(50)]
        public string? fixed_asset_category_code { get; set; }

        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        [MaxLength(255)]
        public string? fixed_asset_category_name { get; set; }

        /// <summary>
        /// Ngày mua
        /// </summary>
        public DateTime? purchase_date { get; set; }

        /// <summary>
        /// Ngày bắt đầu sử dụng
        /// </summary>
        public DateTime? start_using_date { get; set; }

        /// <summary>
        /// Nguyên giá
        /// </summary>
        public decimal? cost { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        public int? quantity { get; set; }

        /// <summary>
        /// Tỷ lệ hao mòn (%)
        /// </summary>
        public double? depreciation_rate { get; set; }

        /// <summary>
        /// Năm bắt đầu theo dõi tài sản trên phần mềm
        /// </summary>
        public int? tracked_year { get; set; }

        /// <summary>
        /// Số năm sử dụng
        /// </summary>
        public int? life_time { get; set; }

        /// <summary>
        /// Năm sử dụng
        /// </summary>
        public int? production_year { get; set; }
    }
}
