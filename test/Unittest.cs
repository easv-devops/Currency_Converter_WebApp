
using infrastructure.Models;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Dapper;
using FluentAssertions;
using Newtonsoft.Json;
using test;

namespace infrastructure.Tests.Repository
{
    [TestFixture]
    public class ConvRepositoryTests
    {
        [TestCase("USD", "EUR", 100, 85)]
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
    }
}