using Exadel.Compreface.Clients.CompreFaceClient;
using Exadel.Compreface.Services;
using static Exadel.Compreface.AcceptenceTests.UrlConstConfig;

namespace Exadel.Compreface.AcceptenceTests.ConfigurationTest
{
    public class ComprefaceConfigurationTest
    {
        [Fact]
        public void ConfigConstructor_TakesNullForPORTProperty_ThrowsArgumentNullException()
        {
            // Act
            var func = () => new CompreFaceClient(DOMAIN, null);

            // Assert
            Assert.Throws<ArgumentNullException>(func);
        }

        [Fact]
        public void ConfigConstructor_TakesNullForDOMAINProperty_ThrowsArgumentNullException()
        {
            // Act
            var func = () => new CompreFaceClient(null, PORT);

            // Assert
            Assert.Throws<ArgumentNullException>(func);
        }

        [Fact]
        public void ConfigConstructor_TakesNullForAPIKEYProperty_ThrowsArgumentNullException()
        {
            // Act
            var func = () => new CompreFaceClient(DOMAIN, PORT).GetCompreFaceService<DetectionService>(null!);

            // Assert
            Assert.Throws<ArgumentNullException>(func);
        }
    }
}
