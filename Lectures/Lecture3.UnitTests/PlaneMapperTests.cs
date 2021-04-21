using Lecture3.Solid;
using Moq;
using NUnit.Framework;
using System.Linq;
using static Lecture3.Solid.Srp;

namespace Lecture3.UnitTests
{
    [TestFixture]
    public class PlaneMapperTests
    {
        [Test]
        public void MapFromDto_ShouldReturn_ProperResult()
        {
            // Arrange
            var engineMapper = new Mock<IEngineMapper>();
            var logger = new Mock<ILogger>();
            var dto = new PlaneDto();

            var expectedEngineMapperResult = new Engine();
            engineMapper.Setup(_=>_.MapFromDto(It.IsAny<EngineDto>())).Returns(expectedEngineMapperResult).Verifiable();

            var sut = new PlaneMapper(engineMapper.Object, logger.Object);

            // Act
            var result = sut.MapFromDto(dto);

            // Assert
            Assert.NotNull(result.Engines);
            Assert.True(result.Engines.Contains(expectedEngineMapperResult));
        }
    }
}