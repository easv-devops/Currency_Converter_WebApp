using api.Controllers;
using api.Helper;
using api.TransferModels;
using infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using service;

namespace test
{
    [TestFixture]
    public class HistoryControllerTests
    {
        private HistoryController _controller;
        private Mock<HistoryService> _historyServiceMock;
        private Mock<ResponseHelper> _responseHelperMock;
        private Mock<HttpContext> _httpContextMock;
        private Mock<ILogger<HistoryController>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _historyServiceMock = new Mock<HistoryService>();
            _responseHelperMock = new Mock<ResponseHelper>();
            _httpContextMock = new Mock<HttpContext>();
            _loggerMock = new Mock<ILogger<HistoryController>>();

            _controller = new HistoryController(_historyServiceMock.Object, _responseHelperMock.Object, _loggerMock.Object);
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = _httpContextMock.Object
            };
        }
        
        [Test]
        public void GetAllHistory_ShouldReturnSuccessResponseDto_WhenHistoriesExist()
        {
            // Arrange
            var histories = new List<ConversionHistory>
            {
                new ConversionHistory
                {
                    Id = 1,
                    SourceCurrency = "EUR",
                    TargetCurrency = "USD",
                    Amount = 100,
                    ConvertedAmount = 107,
                    Timestamp = DateTime.Now
                },
                new ConversionHistory
                {
                    Id = 2,
                    SourceCurrency = "UDS",
                    TargetCurrency = "EUR",
                    Amount = 100,
                    ConvertedAmount = 93,
                    Timestamp = DateTime.Now
                },
                new ConversionHistory
                {
                    Id = 2,
                    SourceCurrency = "UDS",
                    TargetCurrency = "GBP",
                    Amount = 90,
                    ConvertedAmount = 68,
                    Timestamp = DateTime.Now
                },
                new ConversionHistory
                {
                    Id = 2,
                    SourceCurrency = "GBP",
                    TargetCurrency = "USD",
                    Amount = 89,
                    ConvertedAmount = 117,
                    Timestamp = DateTime.Now
                },
                new ConversionHistory
                {
                    Id = 2,
                    SourceCurrency = "UDS",
                    TargetCurrency = "GBP",
                    Amount = 9,
                    ConvertedAmount = 6,
                    Timestamp = DateTime.Now
                },
            };
            _historyServiceMock.Setup(service => service.GetAllHistories()).Returns(histories);

            var expectedResponseDto = new ResponseDto("Conversion history fetched successfully")
            {
                ResponseData = histories
            };

            _responseHelperMock.Setup(helper =>
                    helper.Success(_httpContextMock.Object, 200, "Conversion history fetched successfully", histories))
                .Returns(expectedResponseDto);

            // Act
            var response = _controller.GetAllHistory();

            // Assert
            Assert.IsInstanceOf<ResponseDto>(response);
            Assert.AreEqual(expectedResponseDto, response);
        }
    }
}