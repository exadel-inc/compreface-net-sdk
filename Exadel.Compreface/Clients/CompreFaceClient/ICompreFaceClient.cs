using Microsoft.Extensions.Configuration;

namespace Exadel.Compreface.Clients.CompreFaceClient
{
    public interface ICompreFaceClient
    {
        T GetCompreFaceService<T>(string apiKey) where T : class;

        T GetCompreFaceService<T>(IConfiguration configuration, string apiKeySection) where T : class;
    }
}