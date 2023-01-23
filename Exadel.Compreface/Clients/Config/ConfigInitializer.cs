using Exadel.Compreface.Helpers;
using Flurl.Http;
using System.Text.Json;

namespace Exadel.Compreface.Clients.Config
{
    /// <summary>
    /// Configures all the needed external configs for services clients/> 
    /// </summary>
    public static class ConfigInitializer
    {
        /// <summary>
        /// Creates the instance of <see cref="SystemJsonSerializer"/> instance and binds it to Flurl's built-in JsonSerializer 
        /// </summary>
        public static void InitializeSnakeCaseJsonConfigs()
        {
            var jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = SnakeCaseToCamelCaseNamingPolicy.Policy,
                PropertyNameCaseInsensitive = true,
            };

            FlurlHttp.GlobalSettings.JsonSerializer = new SystemJsonSerializer(jsonOptions);
        }
    }
}
