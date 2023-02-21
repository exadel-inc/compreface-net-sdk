using Exadel.Compreface.Clients.CompreFaceClient;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;
using Exadel.Compreface.Services;
using Exadel.Compreface.Services.RecognitionService;
using Exadel.Compreface.Exceptions;

namespace Exadel.Compreface.AcceptenceTests.CompreFaceClientTests
{
    public class CompreFaceClientTests
    {
        private readonly ICompreFaceClient _compreFaceClient;

        public CompreFaceClientTests()
        {
            _compreFaceClient = new CompreFaceClient(DOMAIN, PORT);
        }

        [Fact]
        public void CompreFaceClient_SetFaceDetectionService_ReturnsProperService()
        {
            //Act
            var service = _compreFaceClient.GetCompreFaceService<FaceDetectionService>(API_KEY_DETECTION_SERVICE);

            //Assert
            Assert.IsType<FaceDetectionService>(service);
        }

        [Fact]
        public void CompreFaceClient_SetFaceVerificationService_ReturnsProperService()
        {
            //Act
            var service = _compreFaceClient.GetCompreFaceService<FaceVerificationService>(API_KEY_VERIFICATION_SERVICE);

            //Assert
            Assert.IsType<FaceVerificationService>(service);
        }

        [Fact]
        public void CompreFaceClient_SetRecognitionService_ReturnsProperService()
        {
            //Act
            var service = _compreFaceClient.GetCompreFaceService<RecognitionService>(API_KEY_RECOGNITION_SERVICE);

            //Assert
            Assert.IsType<RecognitionService>(service);
        }

        [Fact]
        public void CompreFaceClient_SetRecognitionService_IsBelongsToDefiniteAttribute()
        {
            //Arrange
            var testApiKey = Guid.NewGuid().ToString();

            //Act
            var func = () => _compreFaceClient.GetCompreFaceService<TestService>(testApiKey);

            //Assert
            Assert.Throws<TypeNotBelongCompreFaceException>(func);
        }
    }
}
