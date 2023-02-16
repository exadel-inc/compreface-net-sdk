using Exadel.Compreface.Clients.ApiClient;
using Flurl;
using Flurl.Http.Content;
using Moq;

namespace Exadel.Compreface.UnitTests.Helpers
{
    public abstract class SetupAndVerifyTests
    {
        public Mock<IApiClient> ApiClientMock { get; set; }

        public  SetupAndVerifyTests()
        {
            ApiClientMock = new Mock<IApiClient>();
        }

        public void SetupGetBytesFromRemote()
        {
            ApiClientMock.Setup(service =>
                service.GetBytesFromRemoteAsync(
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(Array.Empty<byte>());
        }

        public void VerifyGetBytesFromRemote()
        {
            ApiClientMock.Verify(service =>
                service.GetBytesFromRemoteAsync(
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        public void SetupGetJson<TResponse>() where TResponse : new()
        {
            ApiClientMock.Setup(service =>
                service.GetJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        public void SetupGetJson<TResponse, TUrl>() where TResponse : new()
        {
            ApiClientMock.Setup(service =>
                service.GetJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        public void VerifyGetJson<TResponse>()
        {
            ApiClientMock.Verify(service =>
                service.GetJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        public void VerifyGetJson<TResponse, TUrl>()
        {
            ApiClientMock.Verify(service =>
                service.GetJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        public void SetupPostMultipart<TResponse>() where TResponse : new()
        {
            ApiClientMock.Setup(service =>
                service.PostMultipartAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<Action<CapturedMultipartContent>>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        public void VerifyPostMultipart<TResponse>()
        {
            ApiClientMock.Verify(service =>
            service.PostMultipartAsync<TResponse>(
                It.IsAny<Url>(),
                It.IsAny<Action<CapturedMultipartContent>>(),
                It.IsAny<HttpCompletionOption>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        public void SetupPostJson<TResponse>() where TResponse : class, new()
        {
           
                ApiClientMock.Setup(service =>
                service.PostJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        public void VerifyPostJson<TResponse>() where TResponse : class, new()
        {
            ApiClientMock.Verify(service =>
            service.PostJsonAsync<TResponse>(
                It.IsAny<Url>(),
                It.IsAny<object>(),
                It.IsAny<HttpCompletionOption>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        public void SetupPostJson<TResponse, TUrl>() where TResponse : class, new()
        {
            if (typeof(TUrl).IsEquivalentTo(typeof(Url)))
            {
                ApiClientMock.Setup(service =>
                service.PostJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
            }
            else if (typeof(TUrl).IsEquivalentTo(typeof(string)))
            {
                ApiClientMock.Setup(service =>
                service.PostJsonAsync<TResponse>(
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

        public void VerifyPostJson<TResponse, TUrl>() where TResponse : class, new()
        {
            if (typeof(TUrl).IsEquivalentTo(typeof(Url)))
            {
                ApiClientMock.Verify(service =>
                service.PostJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
            }
            else if (typeof(TUrl).IsEquivalentTo(typeof(string)))
            {
                ApiClientMock.Verify(service =>
                service.PostJsonAsync<TResponse>(
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

        public void SetupPutJson<TResponse>() where TResponse : class, new()
        {
            ApiClientMock.Setup(service =>
                service.PutJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        public void VerifyPutJson<TResponse>() where TResponse : class
        {
            ApiClientMock.Verify(service =>
                service.PutJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        public void SetupDeleteJson<TResponse>() where TResponse : class, new()
        {
            ApiClientMock.Setup(service =>
                service.DeleteJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        public void SetupDeleteJson<TResponse, TUrl>() where TResponse : class, new()
        {
            ApiClientMock.Setup(service =>
                service.DeleteJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        public void VerifyDeleteJson<TResponse>() where TResponse : class
        {
            ApiClientMock.Verify(service =>
                service.DeleteJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        public void VerifyDeleteJson<TResponse, TUrl>() where TResponse : class
        {
            ApiClientMock.Verify(service =>
                service.DeleteJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        public void SetupGetBytes()
        {
            ApiClientMock.Setup(service =>
                service.GetBytesAsync(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new byte[] { });
        }

        public void VerifySetupGetBytes()
        {
            ApiClientMock.Verify(service =>
                service.GetBytesAsync(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        public void VerifySetupGetBytes2Times()
        {
            ApiClientMock.Verify(service =>
                service.GetBytesAsync(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Exactly(2));
        }
    }
}