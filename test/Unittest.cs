namespace test;
using api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using service;

[TestFixture]
public class Unittest
{
    
    private ConversionController _conversionController;
    private Mock<ILogger<ConversionController>> _loggerMock;
    private Mock<ConverterService> _converterServiceMock;
    private Mock<HistoryService> _historyServiceMock;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<ConversionController>>();
        _converterServiceMock = new Mock<ConverterService>();
        _historyServiceMock = new Mock<HistoryService>();
        _conversionController = new ConversionController(_loggerMock.Object, _converterServiceMock.Object, _historyServiceMock.Object);
    }

    [TestCase(-100.0, "USD", "EUR", "Invalid amount")]
    [TestCase(100.0, "USD", "EUR", 500)] // Testing exception scenario
    [TestCase(100.0, "USD", "EUR", 85.0)] // Testing valid scenario
    public void ConvertCurrency_ReturnsExpectedResult(decimal amount, string fromCurrency, string toCurrency, object expectedResult)
    {
        if (expectedResult is string expectedErrorMessage)
        {
            // Arrange for invalid amount scenario
            // Act
            IActionResult result = _conversionController.ConvertCurrency(amount, fromCurrency, toCurrency);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult.Value, Is.EqualTo(expectedErrorMessage));
        }
        else if (expectedResult is int expectedStatusCode)
        {
            // Arrange for exception scenario
            _converterServiceMock.Setup(x => x.ConvertCurrency(amount, fromCurrency, toCurrency)).Throws(new Exception("Some error message"));

            // Act
            IActionResult result = _conversionController.ConvertCurrency(amount, fromCurrency, toCurrency);

            // Assert
            Assert.That(result, Is.TypeOf<StatusCodeResult>());
            var statusCodeResult = result as StatusCodeResult;
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(expectedStatusCode));
        }
        else
        {
            // Arrange for valid amount scenario
            decimal expectedValue = Convert.ToDecimal(expectedResult);
            _converterServiceMock.Setup(x => x.ConvertCurrency(amount, fromCurrency, toCurrency)).Returns(expectedValue);

            // Act
            IActionResult result = _conversionController.ConvertCurrency(amount, fromCurrency, toCurrency);

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult.Value, Is.EqualTo(expectedValue));
        }
    }
}
