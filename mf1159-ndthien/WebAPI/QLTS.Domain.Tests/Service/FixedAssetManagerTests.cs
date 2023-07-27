using NSubstitute;
using NSubstitute.ReturnsExtensions;
using QLTS.Domain.Service.FixedAsset;
using QLTS.Domain.Tests.Service;
using QLTS.Infrastructure;
using QLTS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Domain.Tests
{
    [TestFixture]
    public class FixedAssetManagerTests
    {
        [Test]
        public void CheckFixedAssetExistByCode_ExistFixedAsset_ConflictException()
        {
            // Arrange
            var code = "Hello world";
            
            var fixedAssetRepository = Substitute.For<FixedAssetRepository>();

            fixedAssetRepository.FindFixedAssetByCodeAsync(code).Returns(new FixedAsset());

            var fixedAssetManager = new FixedAssetManager(fixedAssetRepository);
           
            // Act & Assert
            Assert.ThrowsAsync<ConflictException>( async() => await fixedAssetManager.CheckFixedAssetExistByCode(code));

            fixedAssetRepository.Received(1).FindFixedAssetByCodeAsync(code);
        }

        [Test]
        public async Task CheckFixedAssetExistByCode_ExistFixedAsset_Success()
        {
            // Arrange
            var code = "Hello world";

            var fixedAssetRepositoryFake = new FixedAssetRepositoryFake();

            var fixedAssetManager = new FixedAssetManager(fixedAssetRepositoryFake);

            // Act
            await fixedAssetManager.CheckFixedAssetExistByCode(code);

            // Assert
            Assert.That(fixedAssetRepositoryFake.TotalCall, Is.EqualTo(1));
        }
    }
}
