using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Exceptions;
using Exadel.Compreface.Services;
using Flurl;
using Flurl.Http;
using Flurl.Http.Content;

namespace Exadel.Compreface.Clients;

/// <summary>
/// Wrapper on top of Flurl.Http package's extension methods
/// </summary>
public class ApiClient : IApiClient
{
    private readonly string _domain;
    private readonly string _port;

    private readonly Dictionary<ServiceDictionaryKey, AbstractBaseService> _services = new();

    public ApiClient(IComprefaceConfiguration configuration)
        : this(configuration.Domain, configuration.Port) { }

    public ApiClient(string domain, string port)
    {
        _domain = domain;
        _port = port;
    }

    public T GetService<T>(string apiKey) where T : AbstractBaseService
    {
        var key = new ServiceDictionaryKey(apiKey, typeof(T));
        var baseService = _services.GetValueOrDefault(key);

        if (baseService == null)
        {
            var config = new ComprefaceConfiguration(key.ApiKey, _domain, _port);
            baseService = Activator.CreateInstance(typeof(T), config, this) as T;

            _services.Add(key, baseService!);
        }

        return (baseService as T)!;
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

    private class ServiceDictionaryKey
    {
        public string ApiKey { get; set; }

        public Type Type { get; set; }

        public ServiceDictionaryKey(string apiKey, Type type)
        {
            ApiKey = apiKey;
            Type = type;
        }
    }
}