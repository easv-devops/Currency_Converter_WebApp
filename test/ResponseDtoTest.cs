using NUnit.Framework;
using api.TransferModels;

namespace test
{
    [TestFixture]
    public class ResponseDtoTests
    {
        [Test]
        public void ResponseDto_WithMessage_CorrectlyInitialized()
        {
            // Arrange
            string expectedMessage = "Test message";

            // Act
            var responseDto = new ResponseDto(expectedMessage);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseDto.MessageToClient, Is.EqualTo(expectedMessage));
                Assert.That(responseDto.ResponseData, Is.Null);
            });
        }

        [Test]
        public void ResponseDto_DefaultConstructor_CorrectlyInitialized()
        {
            // Arrange & Act
            var responseDto = new ResponseDto();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseDto.MessageToClient, Is.Null);
                Assert.That(responseDto.ResponseData, Is.Null);
            });
        }

        [Test]
        public void ResponseDto_SetResponseData_CorrectlySet()
        {
            // Arrange
            var responseData = new { Value = "Test" };

            // Act
            var responseDto = new ResponseDto();
            responseDto.ResponseData = responseData;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseDto.MessageToClient, Is.Null);
                Assert.That(responseDto.ResponseData, Is.EqualTo(responseData));
            });
        }
    }
}