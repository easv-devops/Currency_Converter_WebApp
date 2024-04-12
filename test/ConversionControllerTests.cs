using api.Controllers;
using infrastructure.Models;
using infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using service;

namespace test
{
    [TestFixture]
    public class ConversionControllerTests
    {
        private ConversionController _controller;

        [SetUp]
        public void Setup()
        {
            var logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<ConversionController>();
            var converterService = new ConverterService();
            var historyService = new HistoryService(new ConvRepository(null!));

            _controller = new ConversionController(logger, converterService, historyService);
        }


        [Test]
        public void ConvertCurrency_ShouldReturnBadRequest_WhenInvalidCurrencyIsProvided()
        {
            // Arrange
            decimal amount = 100;
            string? fromCurrency = "INVALID";
            string? toCurrency = "EUR";

            // Act
            var result = _controller.ConvertCurrency(amount, fromCurrency, toCurrency);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult, Is.Not.Null);
            Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));
        }



        [Test]
        public void ConvertCurrency_ShouldReturnBadRequest_WhenSourceCurrencyIsNull()
        {
            // Arrange
            decimal amount = 100;
            string? fromCurrency = null;
            string? toCurrency = "EUR";

            // Act
            var result = _controller.ConvertCurrency(amount, fromCurrency, toCurrency);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult, Is.Not.Null);
            Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public void ConvertCurrency_ShouldReturnBadRequest_WhenTargetCurrencyIsNull()
        {
            // Arrange
            decimal amount = 100;
            string? fromCurrency = "USD";
            string? toCurrency = null;

            // Act
            var result = _controller.ConvertCurrency(amount, fromCurrency, toCurrency);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult, Is.Not.Null);
            Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));
        }

        [TearDown]
        public void TearDown()
        {
            //_controller.Dispose();
        }
    }
}
