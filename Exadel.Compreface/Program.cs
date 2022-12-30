using System.Text.Json;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Helpers;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Exadel.Compreface;

public class Program
{
    private static string Compreface => nameof(Compreface);

    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(s =>
            {
                s.AddOptions<ComprefaceConfiguration>().BindConfiguration(Compreface);
            })
            .Build();

        var serviceProvider = host.Services;

        var comprefaceConfiguration = serviceProvider.GetRequiredService<IOptions<ComprefaceConfiguration>>().Value;
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        
        FlurlHttp.GlobalSettings.BeforeCall += call =>
        {
            call.Request.Headers.Add("x-api-key", comprefaceConfiguration.ApiKey);
        };

        var jsonOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = SnakeCaseToCamelCaseNamingPolicy.Policy,
            PropertyNameCaseInsensitive = true,
        };

        FlurlHttp.GlobalSettings.JsonSerializer = new SystemJsonSerializer(jsonOptions);
        
        var comprefaceClientV1 = new ComprefaceClient(configuration: configuration, sectionForApiKey: "Compreface:ApiKey (optional naming)", sectionForBaseUrl: "Compreface:BaseUrl (optional naming)");
        var comprefaceClientV2 = new ComprefaceClient(apiKey: "COMPREFACE API KEY", host: "HOST BASE URL");
        var comprefaceClientV3 = new ComprefaceClient(comprefaceConfiguration);
    }
}