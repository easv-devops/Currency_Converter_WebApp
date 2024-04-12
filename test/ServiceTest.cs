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


/*[TestCase("USD", "EUR", 100, 85)]
[TestCase("EUR", "GBP", 200, 170)]
[TestCase("GBP", "JPY", 150, 23250)]
public async Task AddConversion_SuccessfullyAddsConversion(
    string sourcecurrency, string targetcurrency, decimal amount,
    decimal convertedamount)
{
    // Arrange
    Helper.TriggerRebuild();

    // Create a new instance of ConversionHistory
    var history = new ConversionHistory
    {
        Id = 800,
        SourceCurrency = sourcecurrency,
        TargetCurrency = targetcurrency,
        Amount = amount,
        ConvertedAmount = convertedamount,
        Timestamp = DateTime.Now
    };

    // Act
    var httpResponse = await new HttpClient().PostAsJsonAsync
        (Helper.ApiBaseUrl + "/history", history);
    var boxFromResponseBody =
        JsonConvert.DeserializeObject<ConversionHistory>
            (await httpResponse.RequestMessage?.Content?.ReadAsStringAsync()!);

    // Assert
    await using var conn = await Helper.DataSource.OpenConnectionAsync();
    var result = await conn.QueryFirstOrDefaultAsync<ConversionHistory>("SELECT * FROM public.conversionhistory;");
}
}*/