﻿using Exadel.Compreface.Configuration;
using Flurl.Http.Content;
using Flurl.Http;
using Flurl;
using Exadel.Compreface.Exceptions;
using Exadel.Compreface.Clients.Config;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("Exadel.Compreface.UnitTests")]
[assembly: InternalsVisibleTo("Exadel.Compreface.AcceptenceTests")]
namespace Exadel.Compreface.Services
{
    public abstract class CompreFaceProvider
    {
        protected IComprefaceConfiguration Configuration { get; private set; }

        public CompreFaceProvider(IComprefaceConfiguration configuration)
        {
            Configuration = configuration;

            ConfigInitializer.InitializeSnakeCaseJsonConfigs();
        }

        internal virtual async Task<TResponse> GetJsonAsync<TResponse>(
            Url requestUrl,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await requestUrl
                    .WithHeader("x-api-key", Configuration.ApiKey)
                    .GetAsync(completionOption, cancellationToken: cancellationToken)
                    .ReceiveJson<TResponse>();

                return response;
            }
            catch (FlurlHttpTimeoutException exception)
            {
                throw await ThrowServiceTimeoutExceptionAsync(exception);
            }
            catch (FlurlHttpException exception)
            {
                throw await ThrowServiceExceptionAsync(exception);
            }
        }

        internal virtual async Task<TResponse> GetJsonAsync<TResponse>(
            string requestUrl,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            var url = new Url(requestUrl);

            var response = await GetJsonAsync<TResponse>(url, completionOption, cancellationToken);

            return response;
        }

        internal virtual async Task<TResponse> PostJsonAsync<TResponse>(
            Url requestUrl,
            object body,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
            where TResponse : class
        {
            try
            {
                var response = await requestUrl
                    .WithHeader("x-api-key", Configuration.ApiKey)
                    .PostJsonAsync(body, completionOption, cancellationToken)
                    .ReceiveJson<TResponse>();

                return response;
            }
            catch (FlurlHttpTimeoutException exception)
            {
                throw await ThrowServiceTimeoutExceptionAsync(exception);
            }
            catch (FlurlHttpException exception)
            {
                throw await ThrowServiceExceptionAsync(exception);
            }
        }

        internal virtual async Task<TResponse> PostJsonAsync<TResponse>(
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

        internal virtual async Task<TResponse> PutJsonAsync<TResponse>(
            Url requestUrl,
            object body,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await requestUrl
                    .WithHeader("x-api-key", Configuration.ApiKey)
                    .PutJsonAsync(body, completionOption, cancellationToken)
                    .ReceiveJson<TResponse>();

                return response;
            }
            catch (FlurlHttpTimeoutException exception)
            {
                throw await ThrowServiceTimeoutExceptionAsync(exception);
            }
            catch (FlurlHttpException exception)
            {
                throw await ThrowServiceExceptionAsync(exception);
            }
        }

        internal virtual async Task<TResponse> PutJsonAsync<TResponse>(
            string requestUrl,
            object body,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            var url = new Url(requestUrl);

            var response = await PutJsonAsync<TResponse>(url, body, completionOption, cancellationToken);

            return response;
        }

        internal virtual async Task<TResponse> DeleteJsonAsync<TResponse>(
            Url requestUrl,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await requestUrl
                    .WithHeader("x-api-key", Configuration.ApiKey)
                    .DeleteAsync(completionOption, cancellationToken)
                    .ReceiveJson<TResponse>();

                return response;
            }
            catch (FlurlHttpTimeoutException exception)
            {
                throw await ThrowServiceTimeoutExceptionAsync(exception);
            }
            catch (FlurlHttpException exception)
            {
                throw await ThrowServiceExceptionAsync(exception);
            }
        }

        internal virtual async Task<TResponse> DeleteJsonAsync<TResponse>(
            string requestUrl,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            var url = new Url(requestUrl);

            var response = await DeleteJsonAsync<TResponse>(url, completionOption, cancellationToken);

            return response;
        }

        internal virtual async Task<TResponse> PostMultipartAsync<TResponse>(
            Url requestUrl,
            Action<CapturedMultipartContent> buildContent,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await requestUrl
                    .WithHeader("x-api-key", Configuration.ApiKey)
                    .PostMultipartAsync(buildContent, completionOption, cancellationToken)
                    .ReceiveJson<TResponse>();

                return response;
            }
            catch (FlurlHttpTimeoutException exception)
            {
                throw await ThrowServiceTimeoutExceptionAsync(exception);
            }
            catch (FlurlHttpException exception)
            {
                throw await ThrowServiceExceptionAsync(exception);
            }
        }

        internal virtual async Task<TResponse> PostMultipartAsync<TResponse>(
            string requestUrl,
            Action<CapturedMultipartContent> buildContent,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            var url = new Url(requestUrl);

            var response = await PostMultipartAsync<TResponse>(url, buildContent, completionOption, cancellationToken);

            return response;
        }

        internal virtual async Task<byte[]> GetBytesFromRemoteAsync(
            Url requestUrl,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await requestUrl
                    .WithHeader("x-api-key", Configuration.ApiKey)
                    .GetBytesAsync(completionOption, cancellationToken);

                return response;
            }
            catch (FlurlHttpTimeoutException exception)
            {
                throw await ThrowServiceTimeoutExceptionAsync(exception);
            }
            catch (FlurlHttpException exception)
            {
                throw await ThrowServiceExceptionAsync(exception);
            }
        }

        internal virtual async Task<byte[]> GetBytesFromRemoteAsync(
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
