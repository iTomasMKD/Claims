using Claims.Auditing;
using Claims.Controllers;
using Claims.Models;
using Claims.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Azure.Cosmos;
using Moq;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net;
using Xunit;

namespace Claims.Tests
{
    public class ClaimsControllerTests
    {
        //[Fact]
        //public async Task Get_Claims()
        //{
        //    var application = new WebApplicationFactory<Program>()
        //        .WithWebHostBuilder(_ =>
        //        {});

        //    var client = application.CreateClient();

        //    var response = await client.GetAsync("/Claims");

        //    response.EnsureSuccessStatusCode();

        //    //TODO: Apart from ensuring 200 OK being returned, what else can be asserted?
        //}

        [Fact]
        public async Task Get_Claims()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(_ =>
                { });

            var client = application.CreateClient();

            var response = await client.GetAsync("/Claims");

            response.EnsureSuccessStatusCode();

            // Check content type
            Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);

            // Deserialize response body
            var responseString = await response.Content.ReadAsStringAsync();
            var claims = JsonConvert.DeserializeObject<List<Claim>>(responseString);

            // Check claims
            Assert.NotNull(claims);
            Assert.NotEmpty(claims); // or use Assert.Equal if you know the exact number of items
        }


        //[Fact]
        //public async Task Get_Claim_Should_Return_Claim_When_Id_Exists()
        //{
        //    // Arrange
        //    var application = new WebApplicationFactory<Program>()
        //                          .WithWebHostBuilder(_ =>{ });
        //    var client = application.CreateClient();

        //    var mockContainer = new Mock<IContainer>();
        //    var expectedClaim = new Claim { Id = "testId", /* other properties */ };
        //    mockContainer.Setup(c => c.ReadItemAsync<Claim>(It.IsAny<string>(), It.IsAny<PartitionKey>()))
        //                 .ReturnsAsync(new ItemResponse<Claim>(HttpStatusCode.OK, expectedClaim));
        //    var controller = new ClaimsController(mockContainer.Object);


        //    var result = await controller.GetClaimAsync("testId");

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(expectedClaim, result);
        //}

        //[Fact]
        //public async Task CreateAsync_Should_Return_OkResult_When_Claim_Is_Created()
        //{
        //    // Arrange
        //    var mockCosmosDbService = new Mock<ICosmosDbService>();
        //    var mockAuditer = new Mock<Auditer>();
        //    var claim = new Claim { /* set properties except Id */ };
        //    var controller = new ClaimsController(mockCosmosDbService.Object, mockAuditer.Object);

        //    // Act
        //    var result = await controller.CreateAsync(claim);

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);
        //    var okResult = result as OkObjectResult;
        //    var returnedClaim = okResult.Value as Claim;
        //    Assert.Equal(claim, returnedClaim);
        //    mockCosmosDbService.Verify(m => m.AddItemAsync(It.IsAny<Claim>()), Times.Once);
        //    mockAuditer.Verify(m => m.AuditClaim(It.IsAny<string>(), "POST"), Times.Once);
        //}
    }
}
