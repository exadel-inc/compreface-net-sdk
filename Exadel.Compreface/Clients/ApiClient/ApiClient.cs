using Exadel.Compreface.Configuration;
using Flurl.Http.Content;
using Flurl.Http;
using Flurl;
using Exadel.Compreface.Exceptions;
using Microsoft.Extensions.Logging;
using Exadel.Compreface.Clients.Config;

namespace Exadel.Compreface.Clients.ApiClient
{
    public class ApiClient : IApiClient
    {
        private readonly IComprefaceConfiguration _configuration;

        public ApiClient(IComprefaceConfiguration configuration)
        {
            _configuration = configuration;

            ConfigInitializer.InitializeSnakeCaseJsonConfigs();
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> GetJsonAsync<TResponse>(
            Url requestUrl,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await requestUrl
                    .WithHeader("x-api-key", _configuration.ApiKey)
                    .GetAsync(completionOption, cancellationToken: cancellationToken)
                    .ReceiveJson<TResponse>();

                return response;
            }
            catch (FlurlHttpTimeoutException exception)
            {
                throw exception;
            }
            catch (FlurlHttpException exception)
            {
                throw exception;
            }
        }

        public async Task<TResponse> GetJsonAsync<TResponse>(
            string requestUrl,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            var url = new Url(requestUrl);

            var response = await GetJsonAsync<TResponse>(url, completionOption, cancellationToken);

            return response;
        }

        public async Task<TResponse> PostJsonAsync<TResponse>(
            Url requestUrl,
            object body,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)

            where TResponse : class
        {
            try
            {

       _logger.LogInformation("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!some info");
                var response = await requestUrl
                    .WithHeader("x-api-key", _configuration.ApiKey)
                    .PostJsonAsync(body, completionOption, cancellationToken)
                    .ReceiveJson<TResponse>();

                return response;
            }
            catch (FlurlHttpTimeoutException exception)
            {
                throw exception;
            }
            catch (FlurlHttpException exception)
            {
                throw exception;
            }
        }

        public async Task<TResponse> PostJsonAsync<TResponse>(
            string requestUrl,
            object body,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
            where TResponse : class
        {
            var url = new Url(requestUrl);

            var response = await PostJsonAsync<TResponse>(url, body, completionOption, cancellationToken);
            return response;
        }

        public async Task<TResponse> PutJsonAsync<TResponse>(
            Url requestUrl,
            object body,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await requestUrl
                    .WithHeader("x-api-key", _configuration.ApiKey)
                    .PutJsonAsync(body, completionOption, cancellationToken)
                    .ReceiveJson<TResponse>();

                return response;
            }
            catch (FlurlHttpTimeoutException exception)
            {
                throw exception;
            }
            catch (FlurlHttpException exception)
            {
                throw exception;
            }
        }

        public async Task<TResponse> PutJsonAsync<TResponse>(
            string requestUrl,
            object body,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            var url = new Url(requestUrl);

            var response = await PutJsonAsync<TResponse>(url, body, completionOption, cancellationToken);

            return response;
        }

        public async Task<TResponse> DeleteJsonAsync<TResponse>(
            Url requestUrl,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await requestUrl
                    .WithHeader("x-api-key", _configuration.ApiKey)
                    .DeleteAsync(completionOption, cancellationToken)
                    .ReceiveJson<TResponse>();

                return response;
            }
            catch (FlurlHttpTimeoutException exception)
            {
                throw exception;
            }
            catch (FlurlHttpException exception)
            {
                throw exception;
            }
        }

        public async Task<TResponse> DeleteJsonAsync<TResponse>(
            string requestUrl,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            var url = new Url(requestUrl);

            var response = await DeleteJsonAsync<TResponse>(url, completionOption, cancellationToken);

            return response;
        }

        public async Task<TResponse> PostMultipartAsync<TResponse>(
            Url requestUrl,
            Action<CapturedMultipartContent> buildContent,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await requestUrl
                    .WithHeader("x-api-key", _configuration.ApiKey)
                    .PostMultipartAsync(buildContent, completionOption, cancellationToken)
                    .ReceiveJson<TResponse>();

                return response;
            }
            catch (FlurlHttpTimeoutException exception)
            {
                throw exception;
            }
            catch (FlurlHttpException exception)
            {
                throw exception;
            }
        }

        public async Task<TResponse> PostMultipartAsync<TResponse>(
            string requestUrl,
            Action<CapturedMultipartContent> buildContent,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            var url = new Url(requestUrl);

            var response = await PostMultipartAsync<TResponse>(url, buildContent, completionOption, cancellationToken);

            return response;
        }

        public async Task<byte[]> GetBytesFromRemoteAsync(
            Url requestUrl,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await requestUrl
                    .WithHeader("x-api-key", _configuration.ApiKey)
                    .GetBytesAsync(completionOption, cancellationToken);

                return response;
            }
            catch (FlurlHttpTimeoutException exception)
            {
                throw exception;
            }
            catch (FlurlHttpException exception)
            {
                throw exception;
            }
        }

        public async Task<byte[]> GetBytesFromRemoteAsync(
            string requestUrl,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            var url = new Url(requestUrl);

            var response = await GetBytesFromRemoteAsync(url, completionOption, cancellationToken);

            return response;
        }

        private static async Task<ServiceTimeoutException> ThrowServiceTimeoutExceptionAsync(FlurlHttpTimeoutException exception)
        {
            var exceptionMessage = await exception.GetResponseStringAsync();
            return new ServiceTimeoutException(exceptionMessage);
        }

        private static async Task<ServiceException> ThrowServiceExceptionAsync(FlurlHttpException exception)
        {
            var exceptionMessage = await exception.GetResponseStringAsync();
            return new ServiceException(exceptionMessage);
        }
    }
}
