using Claims.Auditing;
using Claims.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Claims.Tests
{
    public class CoversControllerTests
    {
        //private Mock<ILogger<CoversController>> _mockLogger;
        //private Mock<CosmosClient> _mockCosmosClient;
        //private Mock<Container> _mockContainer;
        //private Mock<AuditContext> _mockAuditContext;
        //private Auditer _auditer;
        //private CoversController _controller;

        //public CoversControllerTests()
        //{
        //    _mockLogger = new Mock<ILogger<CoversController>>();
        //    _mockCosmosClient = new Mock<CosmosClient>();
        //    _mockContainer = new Mock<Container>();
        //    _mockAuditContext = new Mock<AuditContext>();
        //    _auditer = new Auditer(_mockAuditContext.Object);
        //    _controller = new CoversController(_mockCosmosClient.Object, _mockAuditContext.Object, _mockLogger.Object);
        //}

        // [Fact]
        //public async Task ComputePremiumAsync_Should_Return_OkResult_When_Valid_Parameters_Are_Passed()
        //{
        //    // Arrange
        //    var startDate = DateOnly.MinValue;
        //    var endDate = DateOnly.MaxValue;
        //    var coverType = CoverType.Basic;

        //    // Act
        //    var result = await _controller.ComputePremiumAsync(startDate, endDate, coverType);

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);
        //}

        //        [Fact]
        //        public async Task GetAsync_Should_Return_OkResult_With_List_Of_Covers()
        //        {
        //            // Arrange
        //            var mockIterator = new Mock<FeedIterator<Cover>>();
        //            mockIterator.Setup(_ => _.HasMoreResults).Returns(false);
        //            _mockContainer.Setup(_ => _.GetItemQueryIterator<Cover>(It.IsAny<QueryDefinition>(), null, null)).Returns(mockIterator.Object);

        //            // Act
        //            var result = await _controller.GetAsync();

        //            // Assert
        //            Assert.IsType<OkObjectResult>(result);
        //            var okResult = result as OkObjectResult;
        //            Assert.IsType<List<Cover>>(okResult.Value);
        //        }

        //        [Fact]
        //        public async Task GetAsync_ById_Should_Return_OkResult_With_Cover_When_Id_Exists()
        //        {
        //            // Arrange
        //            var expectedCover = new Cover { Id = "testId" };
        //            _mockContainer.Setup(_ => _.ReadItemAsync<Cover>(It.IsAny<string>(), It.IsAny<PartitionKey>(), null, default))
        //                          .ReturnsAsync(new ItemResponse<Cover>(HttpStatusCode.OK, expectedCover));

        //            // Act
        //            var result = await _controller.GetAsync("testId");

        //            // Assert
        //            Assert.IsType<OkObjectResult>(result);
        //            var okResult = result as OkObjectResult;
        //            var returnedCover = okResult.Value as Cover;
        //            Assert.Equal(expectedCover, returnedCover);
        //        }

        //        [Fact]
        //        public async Task CreateAsync_Should_Return_OkResult_With_Cover_When_Cover_Is_Created()
        //        {
        //            // Arrange
        //            var cover = new Cover { /* set properties except Id and Premium */ };
        //            _mockContainer.Setup(_ => _.CreateItemAsync(It.IsAny<Cover>(), It.IsAny<PartitionKey>(), null, default))
        //                          .ReturnsAsync(new ItemResponse<Cover>(HttpStatusCode.Created, cover));

        //            // Act
        //            var result = await _controller.CreateAsync(cover);

        //            // Assert
        //            Assert.IsType<OkObjectResult>(result);
        //            var okResult = result as OkObjectResult;
        //            var returnedCover = okResult.Value as Cover;
        //            Assert.Equal(cover, returnedCover);
        //        }

        //        [Fact]
        //        public async Task DeleteAsync_Should_Return_NoContentResult_When_Id_Exists()
        //        {
        //            // Arrange
        //            _mockContainer.Setup(_ => _.DeleteItemAsync<Cover>(It.IsAny<string>(), It.IsAny<PartitionKey>(), null, default))
        //                          .ReturnsAsync(new ItemResponse<Cover>(HttpStatusCode.NoContent));

        //            // Act
        //            var result = await _controller.DeleteAsync("testId");

        //            // Assert
        //            Assert.IsType<NoContentResult>(result);
        //        }


        //    }
        //}
    }
}
    

