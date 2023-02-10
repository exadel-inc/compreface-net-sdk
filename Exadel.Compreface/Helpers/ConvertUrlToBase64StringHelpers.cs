using Flurl.Http;

namespace Exadel.Compreface.Helpers
{
    public static class ConvertUrlToBase64StringHelpers
    {
        public static async Task<string> ConvertUrlAsync(string url)
        {
            var fileSourceImageStream = await url.GetBytesAsync();
            return Convert.ToBase64String(fileSourceImageStream);
        }
    }
}