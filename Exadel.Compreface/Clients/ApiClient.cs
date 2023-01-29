using Exadel.Compreface.Clients.Config;
using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Exceptions;
using Flurl;
using Flurl.Http;
using Flurl.Http.Content;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Exadel.Compreface.UnitTests")]
[assembly: InternalsVisibleTo("Exadel.Compreface.AcceptenceTests")]
namespace Exadel.Compreface.Clients;

/// <summary>
/// Wrapper on top of Flurl.Http package's extension methods
/// </summary>
internal class ApiClient : IApiClient
{
    public ApiClient()
    {
        ConfigInitializer.InitializeSnakeCaseJsonConfigs();
    }

    public async Task<TResponse> GetJsonAsync<TResponse>(
        string apiKey,
        Url requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await requestUrl
                .WithHeader("x-api-key", apiKey)
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

    public async Task<TResponse> GetJsonAsync<TResponse>(
        string apiKey,
        string requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
    {
        var url = new Url(requestUrl);

        var response = await GetJsonAsync<TResponse>(apiKey, url, completionOption, cancellationToken);

        return response;
    }

    public async Task<TResponse> PostJsonAsync<TResponse>(
        string apiKey,
        Url requestUrl,
        object body,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
        where TResponse : class
    {
        try
        {
            var response = await requestUrl
                .WithHeader("x-api-key", apiKey)
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

    public async Task<TResponse> PostJsonAsync<TResponse>(
        string apiKey,
        string requestUrl,
        object body,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
        where TResponse : class
    {
        var url = new Url(requestUrl);

        var response = await PostJsonAsync<TResponse>(apiKey, url, body, completionOption, cancellationToken);
        return response;
    }

    public async Task<TResponse> PutJsonAsync<TResponse>(
        string apiKey,
        Url requestUrl,
        object body,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await requestUrl
                .WithHeader("x-api-key", apiKey)
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

    public async Task<TResponse> PutJsonAsync<TResponse>(
        string apiKey,
        string requestUrl,
        object body,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
    {
        var url = new Url(requestUrl);

        var response = await PutJsonAsync<TResponse>(apiKey, url, body, completionOption, cancellationToken);

        return response;
    }

    public async Task<TResponse> DeleteJsonAsync<TResponse>(
        string apiKey,
        Url requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await requestUrl
                .WithHeader("x-api-key", apiKey)
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

    public async Task<TResponse> DeleteJsonAsync<TResponse>(
        string apiKey,
        string requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
    {
        var url = new Url(requestUrl);

        var response = await DeleteJsonAsync<TResponse>(apiKey, url, completionOption, cancellationToken);

        return response;
    }

    public async Task<TResponse> PostMultipartAsync<TResponse>(
        string apiKey,
        Url requestUrl,
        Action<CapturedMultipartContent> buildContent,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await requestUrl
                .WithHeader("x-api-key", apiKey)
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

    public async Task<TResponse> PostMultipartAsync<TResponse>(
        string apiKey,
        string requestUrl,
        Action<CapturedMultipartContent> buildContent,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
    {
        var url = new Url(requestUrl);

        var response = await PostMultipartAsync<TResponse>(apiKey, url, buildContent, completionOption, cancellationToken);

        return response;
    }

    public async Task<byte[]> GetBytesFromRemoteAsync(
        string apiKey,
        Url requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await requestUrl
                .WithHeader("x-api-key", apiKey)
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

    public async Task<byte[]> GetBytesFromRemoteAsync(
        string apiKey,
        string requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
    {
        var url = new Url(requestUrl);

        var response = await GetBytesFromRemoteAsync(apiKey, url, completionOption, cancellationToken);

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