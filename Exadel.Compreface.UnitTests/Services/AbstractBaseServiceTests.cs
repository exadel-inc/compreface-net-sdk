using Exadel.Compreface.Configuration;
using Flurl.Http.Content;
using Flurl;
using Moq;
using Tynamix.ObjectFiller;
using Exadel.Compreface.Clients.Interfaces;

namespace Exadel.Compreface.UnitTests.Services
{
    public abstract class AbstractBaseServiceTests
    {
        protected ComprefaceConfiguration Configuration { get; }

        protected Mock<IApiClient> ApiClientMock { get; }

        public AbstractBaseServiceTests()
        {
            var apiKey = GetRandomString();
            var domain = GetRandomString();
            var port = GetRandomString();

            Configuration = new ComprefaceConfiguration(apiKey, domain, port);
            ApiClientMock = new Mock<IApiClient>();
        }

        protected void SetupGetBytesFromRemote()
        {
            ApiClientMock.Setup(apiClient =>
                apiClient.GetBytesFromRemoteAsync(
                    Configuration.ApiKey,
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(Array.Empty<byte>());
        }

        protected void VerifyGetBytesFromRemote()
        {
            ApiClientMock.Verify(apiClient =>
                apiClient.GetBytesFromRemoteAsync(
                    Configuration.ApiKey,
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void SetupGetJson<TResponse>() where TResponse : new()
        {
            ApiClientMock.Setup(apiClient =>
                apiClient.GetJsonAsync<TResponse>(
                    Configuration.ApiKey,
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void SetupGetJson<TResponse, TUrl>() where TResponse : new()
        {
            ApiClientMock.Setup(apiClient =>
                apiClient.GetJsonAsync<TResponse>(
                    Configuration.ApiKey,
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void VerifyGetJson<TResponse>()
        {
            ApiClientMock.Verify(apiClient =>
                apiClient.GetJsonAsync<TResponse>(
                    Configuration.ApiKey,
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void VerifyGetJson<TResponse, TUrl>()
        {
            ApiClientMock.Verify(apiClient =>
                apiClient.GetJsonAsync<TResponse>(
                    Configuration.ApiKey,
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void SetupPostMultipart<TResponse>() where TResponse : new()
        {
            ApiClientMock.Setup(apiClient =>
                apiClient.PostMultipartAsync<TResponse>(
                    Configuration.ApiKey,
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
                    Configuration.ApiKey,
                It.IsAny<Url>(),
                It.IsAny<Action<CapturedMultipartContent>>(),
                It.IsAny<HttpCompletionOption>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void SetupPostJson<TResponse, TUrl>() where TResponse : class, new()
        {
            if (typeof(TUrl).IsEquivalentTo(typeof(Url)))
            {
                ApiClientMock.Setup(apiClient =>
                apiClient.PostJsonAsync<TResponse>(
                    Configuration.ApiKey,
                    It.IsAny<Url>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
            }
            else if (typeof(TUrl).IsEquivalentTo(typeof(string)))
            {
                ApiClientMock.Setup(apiClient =>
                apiClient.PostJsonAsync<TResponse>(
                    Configuration.ApiKey,
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
            }
            else
            {
                throw new Exception("Only string and Url types are possible");
            }
        }

        protected void VerifyPostJson<TResponse, TUrl>() where TResponse : class, new()
        {
            if (typeof(TUrl).IsEquivalentTo(typeof(Url)))
            {
                ApiClientMock.Verify(apiClient =>
                apiClient.PostJsonAsync<TResponse>(
                    Configuration.ApiKey,
                    It.IsAny<Url>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
            }
            else if (typeof(TUrl).IsEquivalentTo(typeof(string)))
            {
                ApiClientMock.Verify(apiClient =>
                apiClient.PostJsonAsync<TResponse>(
                    Configuration.ApiKey,
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
            }
            else
            {
                throw new Exception("Only string and Url types are possible");
            }
        }

        protected void SetupPutJson<TResponse>() where TResponse : class, new()
        {
            ApiClientMock.Setup(apiClient =>
                apiClient.PutJsonAsync<TResponse>(
                    Configuration.ApiKey,
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
                    Configuration.ApiKey,
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void SetupDeleteJson<TResponse>() where TResponse : class, new()
        {
            ApiClientMock.Setup(apiClient =>
                apiClient.DeleteJsonAsync<TResponse>(
                    Configuration.ApiKey,
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void SetupDeleteJson<TResponse, TUrl>() where TResponse : class, new()
        {
            ApiClientMock.Setup(apiClient =>
                apiClient.DeleteJsonAsync<TResponse>(
                    Configuration.ApiKey,
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void VerifyDeleteJson<TResponse>() where TResponse : class
        {
            ApiClientMock.Verify(apiClient =>
                apiClient.DeleteJsonAsync<TResponse>(
                    Configuration.ApiKey,
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void VerifyDeleteJson<TResponse, TUrl>() where TResponse : class
        {
            ApiClientMock.Verify(apiClient =>
                apiClient.DeleteJsonAsync<TResponse>(
                    Configuration.ApiKey,
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        protected static string GetRandomString()
        {
            return new Filler<string>().Create();
        }
    }
}
