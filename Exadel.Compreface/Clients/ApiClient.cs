using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Exceptions;
using Flurl;
using Flurl.Http;
using Flurl.Http.Content;

namespace Exadel.Compreface.Clients;

/// <summary>
/// Wrapper on top of Flurl.Http package's extension methods
/// </summary>
public class ApiClient : IApiClient
{
    public readonly string _apiKey;
    
    public ApiClient(string apiKey)
    {
        _apiKey = apiKey;    
    }
    public async Task<TResponse> GetJsonAsync<TResponse>(
        Url requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await requestUrl
                .WithHeader("x-api-key", _apiKey)
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
            var response = await requestUrl
                .WithHeader("x-api-key", _apiKey)
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
                .WithHeader("x-api-key", _apiKey)
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
                .WithHeader("x-api-key", _apiKey)
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
                .WithHeader("x-api-key", _apiKey)
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
                .WithHeader("x-api-key", _apiKey)
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