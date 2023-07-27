using Dapper;
using MySqlConnector;
using QLTS.Domain;
using QLTS.Domain.Interface;
using QLTS.Domain.Resource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace QLTS.Infrastructure
{
    public class FixedAssetRepository : BaseRepository<FixedAsset>, IFixedAssetRepository
    {
        #region Properties
        public override string TableName { get; protected set; } = "fixed_asset";
        public override string TableId { get; protected set; } = "fixed_asset_id";
        #endregion

        #region Constructor
        public FixedAssetRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Find fixed asset by code
        /// </summary>
        /// <param name="code">fixed asset code</param>
        /// <returns>fixed asset result</returns>
        /// Author: NDThien 19/07/2023
        public async Task<FixedAsset?> FindFixedAssetByCodeAsync(string code)
        {
            var sql = $"SELECT * FROM fixed_asset WHERE fixed_asset_code = @code";
            var param = new DynamicParameters();
            param.Add("code", code);
            var result = await _uow.Connection.QueryFirstOrDefaultAsync<FixedAsset>(sql, param, transaction: _uow.Transaction);
            return result;
        }

        /// <summary>
        /// Lấy mã code lớn nhất
        /// </summary>
        /// <returns>Mã code lớn nhất</returns>
        /// Author: NDThien 22/07/2023
        public async Task<string> GetMaxCodeAsync()
        {
            var sql = $"proc_get_max_code_{TableName}";
            var result = await _uow.Connection.QueryFirstOrDefaultAsync<string>(sql, transaction: _uow.Transaction, commandType: CommandType.StoredProcedure);
            return result;
        }

        /// <summary>
        /// Lấy tổng số lượng bản ghi
        /// </summary>
        /// <returns>Tổng số lượng bản ghi</returns>
        /// Author: NDThien 22/07/2023
        public async Task<int> GetTotalRecordsAsync()
        {
            var sql = $"proc_count_total_records_{TableName}";
            var result = await _uow.Connection.QueryFirstOrDefaultAsync<int>(sql, transaction: _uow.Transaction, commandType: CommandType.StoredProcedure);
            return result;
        }

        /// <summary>
        /// Lấy danh sách bản ghi theo điều kiện paging và filter
        /// </summary>
        /// <param name="page_size">Tổng số bản ghi trên một trang</param>
        /// <param name="paze_index">Trang hiện tại</param>
        /// <param name="filter">Điều k iện lọc</param>
        /// <returns>Danh sách tài sản được paging và filtered</returns>
        /// Author: NDThien 27/07/2023
        public async Task<IEnumerable<FixedAsset>> GetPagingRecordsAsync(int papeSize, int pageIndex, string? filter)
        {
            if(filter == "")
            {
                filter = "1";
            }
            var sql = $"SELECT fixed_asset_id, fixed_asset_code, fixed_asset_name, organization_id, organization_code, organization_name, department_id, department_code, department_name, fixed_asset_category_id,  fixed_asset_category_code fixed_asset_category_name, purchase_date, start_using_date, cost, quantity,  depreciation_rate, tracked_year, life_time, production_year, active FROM fixed_asset WHERE {filter} LIMIT @page_size OFFSET @offset";            
            var offset = (pageIndex - 1) * papeSize;

            //var param = new DynamicParameters();
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@page_size", papeSize);
            param.Add("@offset", offset);

            var result = await _uow.Connection.QueryAsync<FixedAsset>(sql, param, transaction: _uow.Transaction, null, CommandType.Text);

            return result;  
        }
        #endregion
    }
}
