using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
using Exadel.Compreface.Services;
using Flurl;

namespace Exadel.Compreface.UnitTests.Services;

public class FaceVerificationTests : AbstractBaseServiceTests
{
    private readonly FaceVerificationService _faceVerificationService;

    public FaceVerificationTests()
    {
        _faceVerificationService = new FaceVerificationService(Configuration, ApiClientMock.Object);
    }

    [Fact]
    public async Task VerifyAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new FaceVerificationRequest()
        {
            FacePlugins = new List<string>()
        };

        SetupPostMultipart<FaceVerificationResponse>();

        // Act
        var response = await _faceVerificationService.VerifyAsync(request);

        // Assert
        Assert.IsType<FaceVerificationResponse>(response);
        VerifyPostMultipart<FaceVerificationResponse>();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task VerifyAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostMultipart<FaceVerificationResponse>();

        // Act
        var responseCall = async () => await _faceVerificationService.VerifyAsync((FaceVerificationRequest)null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(responseCall);
    }

    [Fact]
    public async Task VerifyBase64Async_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new FaceVerificationWithBase64Request()
        {
            FacePlugins = new List<string>()
        };

        SetupPostJson<FaceVerificationResponse, Url>();

        // Act
        var response = await _faceVerificationService.VerifyAsync(request);

        // Assert
        Assert.IsType<FaceVerificationResponse>(response);
        Assert.NotNull(response);
        
        VerifyPostJson<FaceVerificationResponse, Url>();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task VerifyBase64Async_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostJson<FaceVerificationResponse, Url>();

        // Act
        var responseCall = async () => await _faceVerificationService.VerifyAsync((FaceVerificationWithBase64Request)null!);

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
        var responseCall = async () => await _faceVerificationService.VerifyAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(responseCall);
    }
}