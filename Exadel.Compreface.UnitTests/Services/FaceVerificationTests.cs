//using Exadel.Compreface.DTOs.FaceVerificationDTOs;
//using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerification;
//using Exadel.Compreface.DTOs.FaceVerificationDTOs.FaceVerificationWithBase64;
//using Exadel.Compreface.Services;
//using Flurl;

//namespace Exadel.Compreface.UnitTests.Services;

//public class FaceVerificationTests : AbstractBaseServiceTests
//{
//    private readonly FaceVerificationService _faceVerificationService;

//    public FaceVerificationTests()
//    {
//        _faceVerificationService = new FaceVerificationService(Configuration, ApiClientMock.Object);
//    }

//    [Fact]
//    public async Task VerifyImageAsync_TakesRequestModel_ReturnsProperResponseModel()
//    {
//        // Arrange
//        var request = new FaceVerificationRequest()
//        {
//            FacePlugins = new List<string>()
//        };

//        SetupPostMultipart<FaceVerificationResponse>();

//        // Act
//        var response = await _faceVerificationService.VerifyImageAsync(request);

//        // Assert
//        Assert.IsType<FaceVerificationResponse>(response);
//        VerifyPostMultipart<FaceVerificationResponse>();
//        ApiClientMock.VerifyNoOtherCalls();
//    }
    
//    [Fact]
//    public async Task VerifyImageAsync_TakesNullRequestModel_ThrowsNullReferenceException()
//    {
//        // Arrange
//        SetupPostMultipart<FaceVerificationResponse>();

//        // Act
//        var responseCall = async () => await _faceVerificationService.VerifyImageAsync(null!);

//        // Assert
//        await Assert.ThrowsAsync<NullReferenceException>(responseCall);
//    }

//    [Fact]
//    public async Task VerifyImageAsync_TakesIncorrectRequestModel_ThrowsArgumentNullException()
//    {
//        // Arrange
//        var request = new FaceVerificationRequest();

//        SetupPostMultipart<FaceVerificationResponse>();

//        // Act
//        var responseCall = async () => await _faceVerificationService.VerifyImageAsync(request);

//        // Assert
//        await Assert.ThrowsAsync<ArgumentNullException>(responseCall);
//    }

//    [Fact]
//    public async Task VerifyBase64ImageAsync_TakesRequestModel_ReturnsProperResponseModel()
//    {
//        // Arrange
//        var request = new FaceVerificationWithBase64Request()
//        {
//            FacePlugins = new List<string>()
//        };

//        SetupPostJson<FaceVerificationResponse, Url>();

//        // Act
//        var response = await _faceVerificationService.VerifyBase64ImageAsync(request);

//        // Assert
//        Assert.IsType<FaceVerificationResponse>(response);
//        Assert.NotNull(response);
        
//        VerifyPostJson<FaceVerificationResponse, Url>();
//        ApiClientMock.VerifyNoOtherCalls();
//    }
    
//    [Fact]
//    public async Task VerifyBase64ImageAsync_TakesNullRequestModel_ThrowsNullReferenceException()
//    {
//        // Arrange
//        SetupPostJson<FaceVerificationResponse, Url>();
        
//        // Act
//        var responseCall = async () => await _faceVerificationService.VerifyBase64ImageAsync(null!);

//        // Assert
//        await Assert.ThrowsAsync<NullReferenceException>(responseCall);
//    }

//    [Fact]
//    public async Task VerifyBase64ImageAsync_TakesIncorrectRequestModel_ThrowsArgumentArgumentNullException()
//    {
//        // Arrange
//        var request = new FaceVerificationWithBase64Request();

//        SetupPostJson<FaceVerificationResponse, Url>();

//        // Act
//        var responseCall = async () => await _faceVerificationService.VerifyBase64ImageAsync(request);

//        // Assert
//        await Assert.ThrowsAsync<ArgumentNullException>(responseCall);
//    }
//}