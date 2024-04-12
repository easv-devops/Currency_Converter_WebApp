using NUnit.Framework;
using System;
using infrastructure.Models;

namespace test
{
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
                Assert.Multiple(() =>
                {
                    Assert.That(conversionHistory.Id, Is.EqualTo(0));
                    Assert.That(conversionHistory.SourceCurrency, Is.Null);
                    Assert.That(conversionHistory.TargetCurrency, Is.Null);
                    Assert.That(conversionHistory.Amount, Is.EqualTo(0));
                    Assert.That(conversionHistory.ConvertedAmount, Is.EqualTo(0));
                    Assert.That(conversionHistory.Timestamp, Is.EqualTo(default(DateTime)));
                });
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
                Assert.Multiple(() =>
                {
                    Assert.That(conversionHistory.Id, Is.EqualTo(1));
                    Assert.That(conversionHistory.SourceCurrency, Is.EqualTo("USD"));
                    Assert.That(conversionHistory.TargetCurrency, Is.EqualTo("EUR"));
                    Assert.That(conversionHistory.Amount, Is.EqualTo(100));
                    Assert.That(conversionHistory.ConvertedAmount, Is.EqualTo(93));
                    Assert.That(conversionHistory.Timestamp, Is.EqualTo(timestamp));
                });
            }
        }
    }
}
