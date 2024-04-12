using infrastructure.Models;

namespace test;

public class ModelTest
{
    [TestFixture]
    public class ConversionHistoryTests
    {
        [Test]
        public void Properties_InitializedCorrectly()
        {
            // Arrange & Act
            var conversionHistory = new ConversionHistory();

            // Assert
            Assert.AreEqual(0, conversionHistory.Id);
            Assert.IsNull(conversionHistory.SourceCurrency);
            Assert.IsNull(conversionHistory.TargetCurrency);
            Assert.AreEqual(0, conversionHistory.Amount);
            Assert.AreEqual(0, conversionHistory.ConvertedAmount);
            Assert.AreEqual(default(DateTime), conversionHistory.Timestamp);
        }

        [Test]
        public void Properties_CanBeSet()
        {
            // Arrange
            var timestamp = DateTime.Now;

            // Act
            var conversionHistory = new ConversionHistory
            {
                Id = 1,
                SourceCurrency = "USD",
                TargetCurrency = "EUR",
                Amount = 100,
                ConvertedAmount = 93,
                Timestamp = timestamp
            };

            // Assert
            Assert.AreEqual(1, conversionHistory.Id);
            Assert.AreEqual("USD", conversionHistory.SourceCurrency);
            Assert.AreEqual("EUR", conversionHistory.TargetCurrency);
            Assert.AreEqual(100, conversionHistory.Amount);
            Assert.AreEqual(93, conversionHistory.ConvertedAmount);
            Assert.AreEqual(timestamp, conversionHistory.Timestamp);
        }
    }
}