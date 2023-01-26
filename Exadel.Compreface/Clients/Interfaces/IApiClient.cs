using Flurl;
using Flurl.Http.Content;

namespace Exadel.Compreface.Clients.Interfaces;

public interface IApiClient
{
    Task<TResponse> GetJsonAsync<TResponse>(
        string apiKey,
        Url requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default);

    Task<TResponse> GetJsonAsync<TResponse>(
        string apiKey,
        string requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default);

    Task<TResponse> PostJsonAsync<TResponse>(
        string apiKey,
        Url requestUrl,
        object body,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
        where TResponse : class;

    Task<TResponse> PostJsonAsync<TResponse>(
        string apiKey,
        string requestUrl,
        object body,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default)
        where TResponse : class;

    Task<TResponse> PutJsonAsync<TResponse>(
        string apiKey,
        Url requestUrl,
        object body,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default);

    Task<TResponse> PutJsonAsync<TResponse>(
        string apiKey,
        string requestUrl,
        object body,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default);

    Task<TResponse> DeleteJsonAsync<TResponse>(
        string apiKey,
        Url requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default);

    Task<TResponse> DeleteJsonAsync<TResponse>(
        string apiKey,
        string requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default);

    Task<TResponse> PostMultipartAsync<TResponse>(
        string apiKey,
        Url requestUrl,
        Action<CapturedMultipartContent> buildContent,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default);

    Task<TResponse> PostMultipartAsync<TResponse>(
        string apiKey,
        string requestUrl,
        Action<CapturedMultipartContent> buildContent,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default);

    Task<byte[]> GetBytesFromRemoteAsync(
        string apiKey,
        Url requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default);

    Task<byte[]> GetBytesFromRemoteAsync(
        string apiKey,
        string requestUrl,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
        CancellationToken cancellationToken = default);
}