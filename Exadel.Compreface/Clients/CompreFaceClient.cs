using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;

namespace Exadel.Compreface.Clients
{
    public class CompreFaceClient
    {
        private readonly string _domain;

        private readonly string _port;

        private readonly IApiClient _apiClient;

        private readonly Dictionary<ServiceDictionaryKey, AbstractBaseService> _services;

        public CompreFaceClient(IComprefaceConfiguration configuration)
            : this(configuration.Domain, configuration.Port) { }

        public CompreFaceClient(string domain, string port)
        {
            _domain = domain;
            _port = port;

            _apiClient = new ApiClient();
            _services = new();
        }

        public T GetService<T>(string apiKey) where T : AbstractBaseService
        {
            var key = new ServiceDictionaryKey(apiKey, typeof(T));
            var baseService = _services.GetValueOrDefault(key);

            if (baseService == null)
            {
                var config = new ComprefaceConfiguration(key.ApiKey, _domain, _port);
                baseService = Activator.CreateInstance(typeof(T), config, _apiClient) as T;

                _services.Add(key, baseService!);
            }

            return (baseService as T)!;
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
}
