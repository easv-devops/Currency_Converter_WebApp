
/*
using api.Controllers;
using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;
using api.Controllers;
using service;
using infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using api.TransferModels;

[TestFixture]
public class HistoryControllerTests
{
    [Test]
    public void GetAllHistory_Returns_SuccessResponse()
    {
        // Arrange
        var mockHistoryService = new Mock<HistoryService>();
        mockHistoryService.Setup(x => x.GetAllHistories()).Returns(new List<ConversionHistory>());

        var controller = new HistoryController(mockHistoryService.Object, null, null);

        // Act
        var result = controller.GetAllHistory();

        // Assert
        Assert.IsInstanceOf<ResponseDto>(result);

        var response = (ResponseDto)result;
        Assert.AreEqual("Conversion history fetched successfully", response.MessageToClient);
        Assert.NotNull(response.ResponseData);
        // Here you can add additional assertions based on the expected data structure returned in the response
    }

}

[TestFixture]
public class ConversionControllerTests
{
    [Test]
    public void ConvertCurrency_WithValidInput_Returns_Ok()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<ConversionController>>();
        var mockConverterService = new Mock<ConverterService>();
        var mockHistoryService = new Mock<HistoryService>();

        mockConverterService.Setup(x => x.ConvertCurrency(It.IsAny<decimal>(), It.IsAny<string>(), It.IsAny<string>()))
                            .Returns(10); // Assuming a fixed conversion rate for simplicity

        var controller = new ConversionController(mockLogger.Object, mockConverterService.Object, mockHistoryService.Object);

        // Act
        var result = controller.ConvertCurrency(100, "USD", "EUR");

        // Assert
        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.AreEqual(200, okResult.StatusCode);

        // You might want to assert more details about the result content based on the controller implementation
    }

    [Test]
    public void ConvertCurrency_WithInvalidInput_Returns_BadRequest()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<ConversionController>>();
        var mockConverterService = new Mock<ConverterService>();
        var mockHistoryService = new Mock<HistoryService>();

        mockConverterService.Setup(x => x.ConvertCurrency(It.IsAny<decimal>(), It.IsAny<string>(), It.IsAny<string>()))
                            .Throws(new ArgumentException("Invalid currency"));

        var controller = new ConversionController(mockLogger.Object, mockConverterService.Object, mockHistoryService.Object);

        // Act
        var result = controller.ConvertCurrency(100, "INVALID", "EUR");

        // Assert
        var badRequestResult = result as BadRequestObjectResult;
        Assert.NotNull(badRequestResult);
        Assert.AreEqual(400, badRequestResult.StatusCode);
        Assert.AreEqual("Invalid currency", badRequestResult.Value);
    }

    [Test]
    public void ConvertCurrency_WithException_Returns_InternalServerError()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<ConversionController>>();
        var mockConverterService = new Mock<ConverterService>();
        var mockHistoryService = new Mock<HistoryService>();

        mockConverterService.Setup(x => x.ConvertCurrency(It.IsAny<decimal>(), It.IsAny<string>(), It.IsAny<string>()))
                            .Throws(new Exception("Something went wrong"));

        var controller = new ConversionController(mockLogger.Object, mockConverterService.Object, mockHistoryService.Object);

        // Act
        var result = controller.ConvertCurrency(100, "USD", "EUR");

        // Assert
        var internalServerErrorResult = result as ObjectResult;
        Assert.NotNull(internalServerErrorResult);
        Assert.AreEqual(500, internalServerErrorResult.StatusCode);
        Assert.AreEqual("An error occurred while processing the request.", internalServerErrorResult.Value);
    }
}
*/
