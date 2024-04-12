using api.TransferModels;

namespace test;

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
        Assert.AreEqual(expectedMessage, responseDto.MessageToClient);
        Assert.IsNull(responseDto.ResponseData);
    }

    [Test]
    public void ResponseDto_DefaultConstructor_CorrectlyInitialized()
    {
        // Arrange & Act
        var responseDto = new ResponseDto();

        // Assert
        Assert.IsNull(responseDto.MessageToClient);
        Assert.IsNull(responseDto.ResponseData);
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
        Assert.IsNull(responseDto.MessageToClient);
        Assert.AreEqual(responseData, responseDto.ResponseData);
    }
}
