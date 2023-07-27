using MISA.WebFresher05.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data.Common;
using Dapper;

namespace MISA.WebFresher05.Infrastructure
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DbConnection _connection;

        public DepartmentRepository(string connectionstring)
        {
            _connection = new MySqlConnection(connectionstring);
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            var sql = "SELECT * FROM department WHERE is_deleted = 0;";

            var result = await _connection.QueryAsync<Department>(sql);

            return result;
        }

        public async Task<Department> GetAsync(Guid id)
        {
            var sql = "SELECT * FROM department WHERE department_id = @id AND is_deleted = 0";

            var param = new DynamicParameters();

            param.Add("id", id);

            var result = await _connection.QueryFirstOrDefaultAsync<Department>(sql, param);

            if (result == null)
            {
                throw new NotFoundException("Không tìm thấy.");
            }

            return result;
        }
        public async Task<Department?> FindAsync(Guid id)
        {
            var sql = "SELECT * FROM department WHERE department_id = @id AND is_deleted = 0";

            var param = new DynamicParameters();

            param.Add("id", id);

            var result = await _connection.QueryFirstOrDefaultAsync<Department>(sql, param);

            return result;
        }

        public async Task CreateAsync(Department entity)
        {
            var sql = "INSERT INTO department (department_id, department_code, department_name) VALUES (@departmentId, @departmentCode, @departmentName)";

            var param = new DynamicParameters();

            param.Add("@departmentId", entity.department_id);
            param.Add("@departmentCode", entity.department_code);
            param.Add("@departmentName", entity.department_name);

            await _connection.ExecuteAsync(sql, param);
        }

        public async Task UpdateAsync(Department entity)
        {
            var sql = "UPDATE department SET department_code = @departmentCode, department_name = @departmentName WHERE department_id = @id";

            var param = new DynamicParameters();

            param.Add("@id", entity.department_id);
            param.Add("@departmentCode", entity.department_code);
            param.Add("@departmentName", entity.department_name);

            await _connection.ExecuteAsync(sql, param);
        }

        public async Task DeleteAsync(Department entity)
        {
            var sql = "UPDATE department SET is_deleted = 1 WHERE department_id = @id";

            var param = new DynamicParameters();

            param.Add("@id", entity.department_id);

            await _connection.ExecuteAsync(sql, param);
        }
    }
}
