using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
using Exadel.Compreface.Services;
using Flurl;

namespace Exadel.Compreface.UnitTests.Services;

public class FaceVerificationTests : AbstractBaseServiceTests<FaceVerificationService>
{
    private readonly FaceVerificationService _service;

    public FaceVerificationTests()
    {
        _service = ServiceMock.Object;
    }

    [Fact]
    public async Task VerifyAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new FaceVerificationRequest()
        {
            FacePlugins = new List<string>()
        };

        SetupPostJson<FaceVerificationResponse>();

        // Act
        var response = await _service.VerifyAsync(request);

        // Assert
        Assert.IsType<FaceVerificationResponse>(response);
        VerifyPostJson<FaceVerificationResponse>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task VerifyAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostJson<FaceVerificationResponse>();

        // Act
        var responseCall = async () => await _service.VerifyAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(responseCall);
    }

    [Fact]
    public async Task VerifyBase64Async_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new FaceVerificationRequest();

        SetupPostJson<FaceVerificationResponse>();

        // Act
        var responseCall = async () => await _service.VerifyAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(responseCall);
    }

    [Fact]
    public async Task VerifyBase64ImageAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new FaceVerificationWithBase64Request()
        {
            FacePlugins = new List<string>()
        };

        SetupPostJson<FaceVerificationResponse, Url>();

        // Act
        var response = await _service.VerifyAsync(request);

        // Assert
        Assert.IsType<FaceVerificationResponse>(response);
        Assert.NotNull(response);
        
        VerifyPostJson<FaceVerificationResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task VerifyBase64Async_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostJson<FaceVerificationResponse, Url>();

        // Act
        var responseCall = async () => await _service.VerifyAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(responseCall);
    }

    [Fact]
    public async Task VerifyBase64ImageAsync_TakesIncorrectRequestModel_ThrowsArgumentArgumentNullException()
    {
        // Arrange
        var request = new FaceVerificationWithBase64Request();

        SetupPostJson<FaceVerificationResponse, Url>();

        // Act
        var responseCall = async () => await _service.VerifyAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(responseCall);
    }
}