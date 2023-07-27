using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Domain.Tests
{
    public class FixedAssetRepositoryFake : IFixedAssetRepository
    {
        public int TotalCall { get; set; }
        public Task<int> CreateAsync(FixedAsset entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteManyAsync(List<Guid> listId)
        {
            throw new NotImplementedException();
        }

        public Task<FixedAsset?> FindAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<FixedAsset?> FindFixedAssetByCodeAsync(string code)
        {
            TotalCall++;
            return Task.FromResult<FixedAsset?>(default);
        }

        public Task<IEnumerable<FixedAsset>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FixedAsset> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetMaxCodeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(FixedAsset entity)
        {
            throw new NotImplementedException();
        }
    }
}
