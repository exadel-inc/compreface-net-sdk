using Exadel.Compreface.Configuration;
using Flurl.Http.Content;
using Flurl;
using Moq;
using Tynamix.ObjectFiller;

namespace Exadel.Compreface.UnitTests.Services
{
    public abstract class AbstractBaseServiceTests
    {
        protected ComprefaceConfiguration Configuration { get; }

        protected Mock<IApiClient> ApiClientMock { get; }

        public AbstractBaseServiceTests()
        {
            var apiKey = GetRandomString();
            var baseUrl = GetRandomString();

            Configuration = new ComprefaceConfiguration(apiKey, baseUrl);
            ApiClientMock = new Mock<IApiClient>();
        }

        protected void SetupGetJson<TResponse>() where TResponse : new()
        {
            ApiClientMock.Setup(apiClient =>
                apiClient.GetJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void VerifyGetJson<TResponse>()
        {
            ApiClientMock.Verify(apiClient =>
                apiClient.GetJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void SetupPostMultipart<TResponse>() where TResponse : new()
        {
            ApiClientMock.Setup(apiClient =>
                apiClient.PostMultipartAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<Action<CapturedMultipartContent>>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void VerifyPostMultipart<TResponse>()
        {
            ApiClientMock.Verify(apiClient =>
            apiClient.PostMultipartAsync<TResponse>(
                It.IsAny<Url>(),
                It.IsAny<Action<CapturedMultipartContent>>(),
                It.IsAny<HttpCompletionOption>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void SetupPostJson<TResponse>() where TResponse : class, new()
        {
            ApiClientMock.Setup(apiClient =>
                apiClient.PostJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void VerifyPostJson<TResponse>() where TResponse : class, new()
        {
            ApiClientMock.Verify(apiClient =>
                apiClient.PostJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void SetupPutJson<TResponse>() where TResponse : class, new()
        {
            ApiClientMock.Setup(apiClient =>
                apiClient.PutJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void VerifyPutJson<TResponse>() where TResponse : class
        {
            ApiClientMock.Verify(apiClient =>
                apiClient.PutJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void SetupDeleteJson<TResponse>() where TResponse : class, new()
        {
            ApiClientMock.Setup(apiClient =>
                apiClient.DeleteJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void VerifyDeleteJson<TResponse>() where TResponse : class
        {
            ApiClientMock.Verify(apiClient =>
                apiClient.DeleteJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        private static string GetRandomString()
        {
            return new Filler<string>().Create();
        }
    }
}
