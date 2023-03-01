using Exadel.Compreface.Configuration;
using Exadel.Compreface.DTOs.FaceVerificationDTOs;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
using Exadel.Compreface.Services;
using Exadel.Compreface.UnitTests.Helpers;
using Flurl;
using static Exadel.Compreface.UnitTests.Helpers.GetRandomStringHelper;

namespace Exadel.Compreface.UnitTests.Services;

public class FaceVerificationTests : SetupAndVerifyTests
{
    private readonly IComprefaceConfiguration _comprefaceConfiguration;

    private readonly FaceVerificationService _faceVerificationService;

    public FaceVerificationTests()
    {
        var apiKey = GetRandomString();
        var domain = GetRandomString();
        var port = GetRandomString();

        _comprefaceConfiguration = new ComprefaceConfiguration(apiKey, domain, port);

        _faceVerificationService = new FaceVerificationService(_comprefaceConfiguration, ApiClientMock.Object);
    }

    [Fact]
    public async Task VerifyAsync_TakesRequestModel_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new FaceVerificationRequestByFilePath()
        {
            FacePlugins = new List<string>()
        };
        var t = new Result();
        List<Result> results = new List<Result> { t };
        var result = new FaceVerificationResponse() { Result = results };

        SetupPostMultipart<FaceVerificationResponse>();

        // Act
        var response = await _faceVerificationService.VerifyAsync(request);

        // Assert
        Assert.IsType<FaceVerificationResponse>(response);
        VerifyPostMultipart<FaceVerificationResponse>();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task VerifyAsync_TakesRequestModelUsingUrl_ReturnsProperResponseModel()
    {
        // Arrange
        var request = new FaceVerificationRequestByFileUrl()
        {
            FacePlugins = new List<string>()
        };

        SetupPostJson<FaceVerificationResponse>();
        SetupGetBytes();

        // Act
        var response = await _faceVerificationService.VerifyAsync(request);

        // Assert
        Assert.IsType<FaceVerificationResponse>(response);
        VerifyPostJson<FaceVerificationResponse>();
        VerifySetupGetBytes2Times();
        ApiClientMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task VerifyAsync_TakesNullRequestModel_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostMultipart<FaceVerificationResponse>();

        // Act
        var responseCall = async () => await _faceVerificationService.VerifyAsync((FaceVerificationRequestByFilePath)null!);

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(responseCall);
    }

    [Fact]
    public async Task VerifyAsync_TakesNullRequestModelUsingUrl_ThrowsNullReferenceException()
    {
        // Arrange
        SetupPostJson<FaceVerificationResponse>();

        // Act
        var responseCall = async () => await _faceVerificationService.VerifyAsync((FaceVerificationRequestByFileUrl)null!);

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
}