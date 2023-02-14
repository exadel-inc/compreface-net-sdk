using Microsoft.Extensions.Configuration;

namespace Exadel.Compreface.Clients.CompreFaceClient
{
    public interface ICompreFaceClient
    {
        public T GetCompreFaceService<T>(string apiKey) where T : class;

        public T GetCompreFaceService<T>(IConfiguration configuration, string apiKeySection) where T : class;
    }
}