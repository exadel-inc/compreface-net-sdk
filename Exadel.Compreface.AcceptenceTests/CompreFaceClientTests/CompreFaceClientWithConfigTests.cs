using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.Exceptions;
using Exadel.Compreface.Services.RecognitionService;
using Exadel.Compreface.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Exadel.Compreface.AcceptenceTests.CompreFaceClientTests
{
    public class CompreFaceClientWithConfigTests
    {
        private readonly ICompreFaceClient _compreFaceClient;
        private readonly IConfiguration _configuration;

        public CompreFaceClientWithConfigTests()
        {
            var host = Host.CreateDefaultBuilder().Build();
            var serviceProvider = host.Services;

            _configuration = serviceProvider.GetService<IConfiguration>()!;

            _compreFaceClient = new CompreFaceClient(_configuration, "Domain", "Port");
        }

        [Fact]
        public void CompreFaceClientWithConfig_SetFaceDetectionService_ReturnsProperService()
        {
            //Act
            var service = _compreFaceClient.GetCompreFaceService<FaceDetectionService>(_configuration, "FaceDetectionApiKey");

            //Assert
            Assert.IsType<FaceDetectionService>(service);
        }

        [Fact]
        public void CompreFaceClientWithConfig_SetFaceVerificationService_ReturnsProperService()
        {
            //Act
            var service = _compreFaceClient.GetCompreFaceService<FaceVerificationService>(_configuration, "FaceVerificationApiKey");

            //Assert
            Assert.IsType<FaceVerificationService>(service);
        }

        [Fact]
        public void CompreFaceClientWithConfig_SetRecognitionService_ReturnsProperService()
        {
            //Act
            var service = _compreFaceClient.GetCompreFaceService<RecognitionService>(_configuration, "FaceRecognitionApiKey");

            //Assert
            Assert.IsType<RecognitionService>(service);
        }

        [Fact]
        public void CompreFaceClientWithConfig_SetRecognitionService_IsBelongsToDefiniteAttribute()
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
