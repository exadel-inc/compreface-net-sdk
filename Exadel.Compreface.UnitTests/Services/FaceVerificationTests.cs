using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
using Exadel.Compreface.Services;
using Flurl;
using Flurl.Http.Content;
using Moq;
using Tynamix.ObjectFiller;

namespace Exadel.Compreface.UnitTests.Services;

public class FaceVerificationTests
{
    private readonly Mock<IApiClient> _apiClientMock;
    private readonly FaceVerificationService _faceVerificationService;

    public FaceVerificationTests()
    {
        var apiKey = GetRandomString();
        var domain = GetRandomString();
        var port = new Random().Next().ToString();
        var configuration = new ComprefaceConfiguration(apiKey, domain, port);

        _apiClientMock = new Mock<IApiClient>();
        _faceVerificationService = new FaceVerificationService(configuration, _apiClientMock.Object);
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
        var response = await _faceVerificationService.VerifyImageAsync(request);

        // Assert
        Assert.IsType<FaceVerificationResponse>(response);
        VerifyPostMultipart<FaceVerificationResponse>();
        _apiClientMock.VerifyNoOtherCalls();
    }
    
    [Fact]
    public async Task VerifyImageAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostMultipart<FaceVerificationResponse>();

        // Act
        var responseCall = async () => await _faceVerificationService.VerifyImageAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(responseCall);
    }
    
    [Fact]
    public async Task VerifyBase64ImageAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new FaceVerificationWithBase64Request()
        {
            FacePlugins = new List<string>()
        };

        SetupPostJson<FaceVerificationResponse>();

        // Act
        var response = await _faceVerificationService.VerifyBase64ImageAsync(request);

        // Assert
        Assert.IsType<FaceVerificationResponse>(response);
        Assert.NotNull(response);
        
        VerifyPostJson<FaceVerificationResponse>();
        _apiClientMock.VerifyNoOtherCalls();
    }
    
    [Fact]
    public async Task VerifyBase64ImageAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostJson<FaceVerificationResponse>();
        
        // Act
        var responseCall = async () => await _faceVerificationService.VerifyBase64ImageAsync(null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(responseCall);
    }
    
    private void SetupPostMultipart<TResponse>() where TResponse : new()
    {
        _apiClientMock.Setup(apiClient =>
                apiClient.PostMultipartAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<Action<CapturedMultipartContent>>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(new TResponse());
    }
    
    private void VerifyPostMultipart<TResponse>()
    {
        _apiClientMock.Verify(apiClient =>
            apiClient.PostMultipartAsync<TResponse>(
                It.IsAny<Url>(),
                It.IsAny<Action<CapturedMultipartContent>>(),
                It.IsAny<HttpCompletionOption>(),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    private void SetupPostJson<TResponse>() where TResponse : class, new()
    {
        _apiClientMock.Setup(apiClient =>
                apiClient.PostJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(new TResponse());
    }

    private void VerifyPostJson<TResponse>() where TResponse : class, new()
    {
        _apiClientMock.Verify(apiClient =>
            apiClient.PostJsonAsync<TResponse>(
                It.IsAny<Url>(),
                It.IsAny<object>(),
                It.IsAny<HttpCompletionOption>(),
                It.IsAny<CancellationToken>()), Times.Once);
    }
    
    private string GetRandomString()
    {
        return new Filler<string>().Create();
    }
}