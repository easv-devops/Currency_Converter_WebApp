using NUnit.Framework;
using Microsoft.Extensions.Logging;
using api.Controllers;
using Microsoft.AspNetCore.Mvc;
using service;
using Moq;

namespace test
{
    [TestFixture]
    public class ConversionControllerTests
    {
        
        private ConversionController _controller;
        private Mock<ILogger<ConversionController>> _loggerMock;
        private Mock<ConverterService> _converterServiceMock;
        private Mock<HistoryService> _historyServiceMock;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<ConversionController>>();
            _converterServiceMock = new Mock<ConverterService>();
            _historyServiceMock = new Mock<HistoryService>();

            _controller = new ConversionController(_loggerMock.Object, _converterServiceMock.Object, _historyServiceMock.Object);
        }

        [Test]
        public void ConvertCurrency_ShouldReturnOkResult_WhenConversionSucceeds()
        {
            // Arrange
            decimal amount = 100;
            string fromCurrency = "USD";
            string toCurrency = "EUR";
            decimal expectedResult = 93;

            _converterServiceMock.Setup(m => m.ConvertCurrency(amount, fromCurrency, toCurrency)).Returns(expectedResult);

            // Act
            var result = _controller.ConvertCurrency(amount, fromCurrency, toCurrency);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(expectedResult, okResult.Value);
        }

        [Test]
        public void ConvertCurrency_ShouldReturnBadRequest_WhenArgumentExceptionIsThrown()
        {
            // Arrange
            decimal amount = 100;
            string fromCurrency = "XYZ";
            string toCurrency = "EUR";
            string expectedErrorMessage = "Invalid currency";

            _converterServiceMock.Setup(m => m.ConvertCurrency(amount, fromCurrency, toCurrency)).Throws(new ArgumentException(expectedErrorMessage));

            // Act
            var result = _controller.ConvertCurrency(amount, fromCurrency, toCurrency);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.AreEqual(expectedErrorMessage, badRequestResult.Value);
        }

        [Test]
        public void ConvertCurrency_ShouldReturnStatusCode500_WhenUnexpectedExceptionIsThrown()
        {
            // Arrange
            decimal amount = 100;
            string fromCurrency = "USD";
            string toCurrency = "EUR";
            Exception expectedException = new Exception("Unexpected error");

            _converterServiceMock.Setup(m => m.ConvertCurrency(amount, fromCurrency, toCurrency)).Throws(expectedException);

            // Act
            var result = _controller.ConvertCurrency(amount, fromCurrency, toCurrency);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = (StatusCodeResult)result;
            Assert.AreEqual(500, statusCodeResult.StatusCode);
        }
    }
}
