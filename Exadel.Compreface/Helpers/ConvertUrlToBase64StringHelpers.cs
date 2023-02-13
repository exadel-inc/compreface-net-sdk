using Exadel.Compreface.Clients.ApiClient;

namespace Exadel.Compreface.Helpers
{
    public static class ConvertUrlToBase64StringHelpers
    {
        public static async Task<string> ConvertUrlAsync(IApiClient apiClient, string url)
        {
            var fileSourceImageStream = await apiClient.GetBytesAsync(url);
            return Convert.ToBase64String(fileSourceImageStream);
        }
    }
}