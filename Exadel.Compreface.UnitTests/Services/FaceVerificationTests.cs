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
    public async Task VerifyImageAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new FaceVerificationRequest()
        {
            FacePlugins = new List<string>()
        };

        SetupPostMultipart<FaceVerificationResponse>();

        // Act
        var response = await _service.VerifyImageAsync(request);

        // Assert
        Assert.IsType<FaceVerificationResponse>(response);
        VerifyPostMultipart<FaceVerificationResponse>();
        ServiceMock.VerifyNoOtherCalls();
    }
    
    [Fact]
    public async Task VerifyImageAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostMultipart<FaceVerificationResponse>();

        // Act
        var responseCall = async () => await _service.VerifyImageAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(responseCall);
    }

    [Fact]
    public async Task VerifyImageAsync_TakesIncorrectRequestModel_ThrowsArgumentNullException()
    {
        // Arrange
        var request = new FaceVerificationRequest();

        SetupPostMultipart<FaceVerificationResponse>();

        // Act
        var responseCall = async () => await _service.VerifyImageAsync(request);

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
        var response = await _service.VerifyBase64ImageAsync(request);

        // Assert
        Assert.IsType<FaceVerificationResponse>(response);
        Assert.NotNull(response);
        
        VerifyPostJson<FaceVerificationResponse, Url>();
        ServiceMock.VerifyNoOtherCalls();
    }
    
    [Fact]
    public async Task VerifyBase64ImageAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostJson<FaceVerificationResponse, Url>();
        
        // Act
        var responseCall = async () => await _service.VerifyBase64ImageAsync(null!);

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
        var responseCall = async () => await _service.VerifyBase64ImageAsync(request);

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(responseCall);
    }
}