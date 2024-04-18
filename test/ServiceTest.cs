/*
using NUnit.Framework;
using service;

namespace test 
{
    public class ConverterServiceTests
    {
        [Test]
        public void ConvertCurrency_ShouldReturnCorrectConversion_WhenValidCurrenciesAndAmountAreProvided()
        {
            // Arrange
            var converterService = new ConverterService();
            decimal amount = 100;
            string fromCurrency = "USD";
            string toCurrency = "EUR";

            // Act
            decimal result = converterService.ConvertCurrency(amount, fromCurrency, toCurrency);

            // Assert
            Assert.That(result, Is.EqualTo(93));
        }

        [Test]
        public void ConvertCurrency_ShouldThrowException_WhenFromCurrencyIsNotSupported()
        {
            // Arrange
            var converterService = new ConverterService();
            decimal amount = 100;
            string fromCurrency = "XYZ";
            string toCurrency = "EUR";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => converterService.ConvertCurrency(amount, fromCurrency, toCurrency));
        }

        [Test]
        public void ConvertCurrency_ShouldThrowException_WhenToCurrencyIsNotSupported()
        {
            // Arrange
            var converterService = new ConverterService();
            decimal amount = 100;
            string fromCurrency = "USD";
            string toCurrency = "XYZ";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => converterService.ConvertCurrency(amount, fromCurrency, toCurrency));
        }

        [Test]
        public void ConvertCurrency_ShouldReturnSameAmount_WhenFromAndToCurrencyAreSame()
        {
            // Arrange
            var converterService = new ConverterService();
            decimal amount = 100;
            string fromCurrency = "USD";
            string toCurrency = "USD";

            // Act
            decimal result = converterService.ConvertCurrency(amount, fromCurrency, toCurrency);

            // Assert
            Assert.That(result, Is.EqualTo(amount));
        }

        [Test]
        public void ConvertCurrency_ShouldReturnCorrectConversion_WhenValidCurrenciesAndAmountAreProvided_WithDifferentRates()
        {
            // Arrange
            var converterService = new ConverterService();
            decimal amount = 100;
            string fromCurrency = "EUR";
            string toCurrency = "GBP";

            // Act
            decimal result = converterService.ConvertCurrency(amount, fromCurrency, toCurrency);

            // Assert
            Assert.That(result, Is.EqualTo(81.72043010752688172043010753m));
        }

        [Test]
        public void ConvertCurrency_ShouldReturnZero_WhenAmountIsZero()
        {
            // Arrange
            var converterService = new ConverterService();
            decimal amount = 0;
            string fromCurrency = "USD";
            string toCurrency = "EUR";

            // Act
            decimal result = converterService.ConvertCurrency(amount, fromCurrency, toCurrency);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
*/
