using Exadel.Compreface.Configuration;
using Flurl.Http.Content;
using Flurl.Http;
using Flurl;
using Exadel.Compreface.Exceptions;
using Exadel.Compreface.Clients.Config;

namespace Exadel.Compreface.Clients.ApiClient
{
    /// <summary>
    /// Wrapper on top of Flurl.Http package's extension methods
    /// </summary>
    public class ApiClient : IApiClient
    {
        private readonly IComprefaceConfiguration _configuration;

        /// <summary>
        /// ApiClient constructor. 
        /// </summary>
        /// <param name="configuration">IComprefaceConfiguration object with CompreFaceClient settings.</param>
        public ApiClient(IComprefaceConfiguration configuration)
        {
            _configuration = configuration;

            ConfigInitializer.InitializeSnakeCaseJsonConfigs();
        }

        /// <summary>
        /// /// Sends an asynchronous GET request.
        /// </summary>
        /// <typeparam name="TResponse">Response DTO type.</typeparam>
        /// <param name="requestUrl">Endpoint request url</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <exception cref="ServiceException">Throws exception with message from CompreFace API</exception>
        /// <exception cref="ServiceTimeoutException">Throws timeout exception from CompreFace API</exception>
        /// <returns>Response DTO instance</returns>
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
                throw await ThrowServiceTimeoutExceptionAsync(exception);
            }
            //catch (FlurlHttpException exception)
            //{
            //    throw await ThrowServiceExceptionAsync(exception);
            //}
        }

        /// <summary>
        /// Sends an asynchronous GET request.
        /// </summary>
        /// <typeparam name="TResponse">Response DTO type.</typeparam>
        /// <param name="requestUrl">Endpoint request url</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <exception cref="ServiceException">Throws exception with message from CompreFace API</exception>
        /// <exception cref="ServiceTimeoutException">Throws timeout exception from CompreFace API</exception>
        /// <returns>Response DTO instance</returns>
        public async Task<TResponse> GetJsonAsync<TResponse>(
            string requestUrl,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            var url = new Url(requestUrl);

            var response = await GetJsonAsync<TResponse>(url, completionOption, cancellationToken);

            return response;
        }

        /// <summary>
        /// Sends an asynchronous POST request.
        /// </summary>
        /// <typeparam name="TResponse">Response DTO type.</typeparam>
        /// <param name="requestUrl">Endpoint request url</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <exception cref="ServiceException">Throws exception with message from CompreFace API</exception>
        /// <exception cref="ServiceTimeoutException">Throws timeout exception from CompreFace API</exception>
        /// <returns>Response DTO instance</returns>
        public async Task<TResponse> PostJsonAsync<TResponse>(
            Url requestUrl,
            object body,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
            where TResponse : class
        {
            try
            {
                var response = await requestUrl
                    .WithHeader("x-api-key", _configuration.ApiKey)
                    .PostJsonAsync(body, completionOption, cancellationToken)
                    .ReceiveJson<TResponse>();

                return response;
            }
            catch (FlurlHttpTimeoutException exception)
            {
                throw await ThrowServiceTimeoutExceptionAsync(exception);
            }
            //catch (FlurlHttpException exception)
            //{
            //    throw await ThrowServiceExceptionAsync(exception);
            //}
        }

        /// <summary>
        /// Sends an asynchronous POST request.
        /// </summary>
        /// <typeparam name="TResponse">Response DTO type.</typeparam>
        /// <param name="requestUrl">Endpoint request url</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <exception cref="ServiceException">Throws exception with message from CompreFace API</exception>
        /// <exception cref="ServiceTimeoutException">Throws timeout exception from CompreFace API</exception>
        /// <returns>Response DTO instance</returns>
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

        /// <summary>
        /// Sends an asynchronous PUT request.
        /// </summary>
        /// <typeparam name="TResponse">Response DTO type.</typeparam>
        /// <param name="requestUrl">Endpoint request url</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <exception cref="ServiceException">Throws exception with message from CompreFace API</exception>
        /// <exception cref="ServiceTimeoutException">Throws timeout exception from CompreFace API</exception>
        /// <returns>Response DTO instance</returns>
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
                throw await ThrowServiceTimeoutExceptionAsync(exception);
            }
            //catch (FlurlHttpException exception)
            //{
            //    throw await ThrowServiceExceptionAsync(exception);
            //}
        }

        /// <summary>
        /// Sends an asynchronous PUT request.
        /// </summary>
        /// <typeparam name="TResponse">Response DTO type.</typeparam>
        /// <param name="requestUrl">Endpoint request url</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <exception cref="ServiceException">Throws exception with message from CompreFace API</exception>
        /// <exception cref="ServiceTimeoutException">Throws timeout exception from CompreFace API</exception>
        /// <returns>Response DTO instance</returns>
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

        /// <summary>
        /// Sends an asynchronous DELETE request.
        /// </summary>
        /// <typeparam name="TResponse">Response DTO type.</typeparam>
        /// <param name="requestUrl">Endpoint request url</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <exception cref="ServiceException">Throws exception with message from CompreFace API</exception>
        /// <exception cref="ServiceTimeoutException">Throws timeout exception from CompreFace API</exception>
        /// <returns>Response DTO instance</returns>
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
                throw await ThrowServiceTimeoutExceptionAsync(exception);
            }
            //catch (FlurlHttpException exception)
            //{
            //    throw await ThrowServiceExceptionAsync(exception);
            //}
        }

        /// <summary>
        /// Sends an asynchronous DELETE request.
        /// </summary>
        /// <typeparam name="TResponse">Response DTO type.</typeparam>
        /// <param name="requestUrl">Endpoint request url</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <exception cref="ServiceException">Throws exception with message from CompreFace API</exception>
        /// <exception cref="ServiceTimeoutException">Throws timeout exception from CompreFace API</exception>
        /// <returns>Response DTO instance</returns>
        public async Task<TResponse> DeleteJsonAsync<TResponse>(
            string requestUrl,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            var url = new Url(requestUrl);

            var response = await DeleteJsonAsync<TResponse>(url, completionOption, cancellationToken);

            return response;
        }

        /// <summary>
        /// Sends an asynchronous multipart/form-data POST request.
        /// </summary>
        /// <typeparam name="TResponse">Response DTO type.</typeparam>
        /// <param name="requestUrl">Endpoint request url</param>
        /// <param name="buildContent">A delegate for building the content parts.</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <exception cref="ServiceException">Throws exception with message from CompreFace API</exception>
        /// <exception cref="ServiceTimeoutException">Throws timeout exception from CompreFace API</exception>
        /// <returns>Response DTO instance</returns>   
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
                throw await ThrowServiceTimeoutExceptionAsync(exception);
            }
            //catch (FlurlHttpException exception)
            //{
            //    throw await ThrowServiceExceptionAsync(exception);
            //}
        }

        /// <summary>
        /// Sends an asynchronous multipart/form-data POST request.
        /// </summary>
        /// <typeparam name="TResponse">Response DTO type.</typeparam>
        /// <param name="requestUrl">Endpoint request url</param>
        /// <param name="buildContent">A delegate for building the content parts.</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <exception cref="ServiceException">Throws exception with message from CompreFace API</exception>
        /// <exception cref="ServiceTimeoutException">Throws timeout exception from CompreFace API</exception>
        /// <returns>Response DTO instance</returns>   
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

        /// <summary>
        /// Sends an asynchronous GET request.
        /// </summary>
        /// <typeparam name="TResponse">Response DTO type.</typeparam>
        /// <param name="requestUrl">Endpoint request url</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <exception cref="ServiceException">Throws exception with message from CompreFace API</exception>
        /// <exception cref="ServiceTimeoutException">Throws timeout exception from CompreFace API</exception>
        /// <returns>A Task whose result is the response body as a byte array.</returns>
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
                throw await ThrowServiceTimeoutExceptionAsync(exception);
            }
            //catch (FlurlHttpException exception)
            //{
            //    throw await ThrowServiceExceptionAsync(exception);
            //}
        }

        /// <summary>
        /// Sends an asynchronous GET request.
        /// </summary>
        /// <typeparam name="TResponse">Response DTO type.</typeparam>
        /// <param name="requestUrl">Endpoint request url</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <exception cref="ServiceException">Throws exception with message from CompreFace API</exception>
        /// <exception cref="ServiceTimeoutException">Throws timeout exception from CompreFace API</exception>
        /// <returns>A Task whose result is the response body as a byte array.</returns>
        public async Task<byte[]> GetBytesFromRemoteAsync(
            string requestUrl,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            var url = new Url(requestUrl);

            var response = await GetBytesFromRemoteAsync(url, completionOption, cancellationToken);

            return response;
        }

        /// <summary>
        /// Sends an asynchronous GET request.
        /// </summary>
        /// <typeparam name="TResponse">Response DTO type.</typeparam>
        /// <param name="requestUrl">Endpoint request url</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <exception cref="ServiceException">Throws exception with message from CompreFace API</exception>
        /// <exception cref="ServiceTimeoutException">Throws timeout exception from CompreFace API</exception>
        /// <returns>A Task whose result is the response body as a byte array.</returns>
        public async Task<byte[]> GetBytesAsync(
            string url, 
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await url
                    .WithHeader("x-api-key", _configuration.ApiKey)
                    .GetBytesAsync(completionOption, cancellationToken);

                return response;
            }
            catch (FlurlHttpTimeoutException exception)
            {
                throw await ThrowServiceTimeoutExceptionAsync(exception);
            }
            //catch (FlurlHttpException exception)
            //{
            //    throw await ThrowServiceExceptionAsync(exception);
            //}
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