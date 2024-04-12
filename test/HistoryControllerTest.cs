/*
using api.Controllers;
using api.Helper;
using api.TransferModels;
using infrastructure.Models;
using infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using service;

namespace test
{
    [TestFixture]
    public class HistoryControllerTests
    {
        private HistoryController _controller;

        [SetUp]
        public void Setup()
        {
            var logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<HistoryController>();
            var historyService = new HistoryService(new ConvRepository(null!));
            var responseHelper = new ResponseHelper();

            _controller = new HistoryController(historyService, responseHelper, logger);
        }

        [Test]
        public void GetAllHistory_ShouldReturnOkResult_WhenHistoriesExist()
        {
            // Arrange
            // Assuming there are existing histories in the database or service
            // Create some dummy data for histories
            var expectedHistories = new[]
            {
                new ConversionHistory { Id = 1, SourceCurrency = "USD", TargetCurrency = "EUR", Amount = 100, ConvertedAmount = 93 },
                new ConversionHistory { Id = 2, SourceCurrency = "EUR", TargetCurrency = "USD", Amount = 93, ConvertedAmount = 100 }
                // Add more sample histories as needed
            };

            // Act
            var result = _controller.GetAllHistory();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<ResponseDto>(okResult.Value);

            var responseDto = okResult.Value as ResponseDto;
            Assert.IsNotNull(responseDto);
            Assert.AreEqual("Conversion history fetched successfully", responseDto.MessageToClient);

            var responseData = responseDto.ResponseData as ConversionHistory[];
            Assert.IsNotNull(responseData);

            // Assert the count of returned histories
            Assert.AreEqual(expectedHistories.Length, responseData.Length);

            // Optionally, assert each individual history as needed
            for (int i = 0; i < expectedHistories.Length; i++)
            {
                Assert.AreEqual(expectedHistories[i].Id, responseData[i].Id);
                Assert.AreEqual(expectedHistories[i].SourceCurrency, responseData[i].SourceCurrency);
                Assert.AreEqual(expectedHistories[i].TargetCurrency, responseData[i].TargetCurrency);
                // Assert other properties as needed
            }
        }

        [Test]
        public void GetAllHistory_ShouldReturnOkResult_WhenNoHistoriesExist()
        {
            // Arrange
            // Assuming there are no existing histories in the database or service

            // Act
            var result = _controller.GetAllHistory();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<ResponseDto>(okResult.Value);

            var responseDto = okResult.Value as ResponseDto;
            Assert.IsNotNull(responseDto);
            Assert.AreEqual("Conversion history fetched successfully", responseDto.MessageToClient);

            var responseData = responseDto.ResponseData as ConversionHistory[];
            Assert.IsNotNull(responseData);
            Assert.IsEmpty(responseData);
        }

        // Add more tests as needed

        [TearDown]
        public void TearDown()
        {
            //_controller.Dispose();
        }
    }
}
*/
