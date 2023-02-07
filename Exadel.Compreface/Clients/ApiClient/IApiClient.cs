using Flurl;
using Flurl.Http.Content;

namespace Exadel.Compreface.Clients.ApiClient
{
    public interface IApiClient
    {
        internal Task<TResponse> DeleteJsonAsync<TResponse>(string requestUrl, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = default);
        Task<TResponse> DeleteJsonAsync<TResponse>(Url requestUrl, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = default);
        Task<byte[]> GetBytesFromRemoteAsync(string requestUrl, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = default);
        Task<byte[]> GetBytesFromRemoteAsync(Url requestUrl, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = default);
        Task<TResponse> GetJsonAsync<TResponse>(string requestUrl, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = default);
        Task<TResponse> GetJsonAsync<TResponse>(Url requestUrl, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = default);
        Task<TResponse> PostJsonAsync<TResponse>(string requestUrl, object body, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = default) where TResponse : class;
        Task<TResponse> PostJsonAsync<TResponse>(Url requestUrl, object body, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = default) where TResponse : class;
        Task<TResponse> PostMultipartAsync<TResponse>(string requestUrl, Action<CapturedMultipartContent> buildContent, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = default);
        Task<TResponse> PostMultipartAsync<TResponse>(Url requestUrl, Action<CapturedMultipartContent> buildContent, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = default);
        Task<TResponse> PutJsonAsync<TResponse>(string requestUrl, object body, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = default);
        Task<TResponse> PutJsonAsync<TResponse>(Url requestUrl, object body, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = default);
    }
}