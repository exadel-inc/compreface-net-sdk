using Exadel.Compreface.Configuration;
using Flurl.Http.Content;
using Flurl;
using Moq;
using Tynamix.ObjectFiller;

namespace Exadel.Compreface.UnitTests.Services
{
    public abstract class AbstractBaseServiceTests<T> where T : Clients.ApiClient.ApiClient
    {
        protected ComprefaceConfiguration Configuration { get; }

        protected Mock<T> ServiceMock { get; }

        public AbstractBaseServiceTests()
        {
            var apiKey = GetRandomString();
            var domain = GetRandomString();
            var port = GetRandomString();

            Configuration = new ComprefaceConfiguration(apiKey, domain, port);
            ServiceMock = new Mock<T>(Configuration);
        }

        protected void SetupGetBytesFromRemote()
        {
            ServiceMock.Setup(service =>
                service.GetBytesFromRemoteAsync(
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(Array.Empty<byte>());
        }

        protected void VerifyGetBytesFromRemote()
        {
            ServiceMock.Verify(service =>
                service.GetBytesFromRemoteAsync(
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void SetupGetJson<TResponse>() where TResponse : new()
        {
            ServiceMock.Setup(service =>
                service.GetJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void SetupGetJson<TResponse, TUrl>() where TResponse : new()
        {
            ServiceMock.Setup(service =>
                service.GetJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void VerifyGetJson<TResponse>()
        {
            ServiceMock.Verify(service =>
                service.GetJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void VerifyGetJson<TResponse, TUrl>()
        {
            ServiceMock.Verify(service =>
                service.GetJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void SetupPostMultipart<TResponse>() where TResponse : new()
        {
            ServiceMock.Setup(service =>
                service.PostMultipartAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<Action<CapturedMultipartContent>>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void VerifyPostMultipart<TResponse>()
        {
            ServiceMock.Verify(service =>
            service.PostMultipartAsync<TResponse>(
                It.IsAny<Url>(),
                It.IsAny<Action<CapturedMultipartContent>>(),
                It.IsAny<HttpCompletionOption>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void SetupPostJson<TResponse, TUrl>() where TResponse : class, new()
        {
            if (typeof(TUrl).IsEquivalentTo(typeof(Url)))
            {
                ServiceMock.Setup(service =>
                service.PostJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
            }
            else if (typeof(TUrl).IsEquivalentTo(typeof(string)))
            {
                ServiceMock.Setup(service =>
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

        protected void VerifyPostJson<TResponse, TUrl>() where TResponse : class, new()
        {
            if (typeof(TUrl).IsEquivalentTo(typeof(Url)))
            {
                ServiceMock.Verify(service =>
                service.PostJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
            }
            else if (typeof(TUrl).IsEquivalentTo(typeof(string)))
            {
                ServiceMock.Verify(service =>
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

        protected void SetupPutJson<TResponse>() where TResponse : class, new()
        {
            ServiceMock.Setup(service =>
                service.PutJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void VerifyPutJson<TResponse>() where TResponse : class
        {
            ServiceMock.Verify(service =>
                service.PutJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void SetupDeleteJson<TResponse>() where TResponse : class, new()
        {
            ServiceMock.Setup(service =>
                service.DeleteJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void SetupDeleteJson<TResponse, TUrl>() where TResponse : class, new()
        {
            ServiceMock.Setup(service =>
                service.DeleteJsonAsync<TResponse>(
                    It.IsAny<Url>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TResponse());
        }

        protected void VerifyDeleteJson<TResponse>() where TResponse : class
        {
            ServiceMock.Verify(service =>
                service.DeleteJsonAsync<TResponse>(
                    It.IsAny<string>(),
                    It.IsAny<HttpCompletionOption>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }

        protected void VerifyDeleteJson<TResponse, TUrl>() where TResponse : class
        {
            ServiceMock.Verify(service =>
                service.DeleteJsonAsync<TResponse>(
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
