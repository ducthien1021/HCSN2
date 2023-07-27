using AutoMapper;
using NSubstitute;
using QLTS.Domain;
using QLTS.Domain.Interface.FixedAsset;
using QLTS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Application.Tests
{


    [TestFixture]
    public class FixedAssetServiceTests
    {
        public IFixedAssetRepository fixedAssetRepository { get; set; }
        public IMapper mapper { get; set; }
        public IFixedAssetManager fixedAssetManager { get; set; }

        public void SetUp()
        {
            fixedAssetRepository = Substitute.For<IFixedAssetRepository>();
            mapper = Substitute.For<IMapper>();
            fixedAssetManager = Substitute.For<IFixedAssetManager>();
        }

        [Test]
        public async Task DeleteManyAsync_EmptyList_ThrowException()
        {
            // Arrange
            var ids = new List<Guid>();

            var expectedMessage = "Không được truyền danh sách rỗng";

            var fixedAssetService = new FixedAssetService(fixedAssetRepository, mapper, fixedAssetManager);

            // Act & Assert
            var exception = Assert.ThrowsAsync<Exception>(async () => await fixedAssetService.DeleteManyAsync(ids));

            Assert.That(exception.Message, Is.EqualTo(expectedMessage));

        }

        [Test]
        public async Task DeleteManyAsync_List10Items_ThrowException()
        {
            // Arrange
            var ids = new List<Guid>();

            //for (int i = 0; i < 10; i++)
            //{
            //    var newGuid = Guid.NewGuid();
            //    ids.Add(newGuid);
            //}

            var expectedMessage = "Không thể xóa";

            var fixedAssetService = new FixedAssetService(fixedAssetRepository, mapper, fixedAssetManager);

            // Act
            await fixedAssetService.DeleteManyAsync(ids);

            // Assert
            await fixedAssetRepository.Received(1).DeleteManyAsync(ids);
        }
    }
}
