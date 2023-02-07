using Exadel.Compreface.Configuration;
using Exadel.Compreface.Exceptions;
using Exadel.Compreface.Services.Attributes;
using System.Reflection;

namespace Exadel.Compreface.Clients;

/// <summary>
/// Wrapper on top of Flurl.Http package's extension methods
/// </summary>
public class CompreFaceClient : ICompreFaceClient
{
    private readonly string _domain;
    private readonly string _port;

    private readonly Dictionary<ServiceDictionaryKey, object> _services = new();

    public CompreFaceClient(IComprefaceConfiguration configuration)
        : this(configuration.Domain, configuration.Port) { }

    public CompreFaceClient(string domain, string port)
    {
        _domain = domain;
        _port = port;
    }

    public T GetService<T>(string apiKey) where T : class
    {
        try
        {
            var key = new ServiceDictionaryKey(apiKey, typeof(T));
            var baseService = _services.GetValueOrDefault(key);

            if (baseService == null)
            {
                var config = new ComprefaceConfiguration(apiKey, _domain, _port);

                baseService = GetBaseService(typeof(T), config);

                _services.Add(key, baseService!);
            }

            return (T)baseService;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private object GetBaseService(Type type, ComprefaceConfiguration config)
    {
        object baseService = null;

        if (type.GetCustomAttribute(typeof(CompreFaceService)) != null)
            baseService = Activator.CreateInstance(type, config);

        if (baseService == null)
            throw new TypeNotBelongCompreFaceException("Type don't belong CompreFace services. Class should be covered by CompreFaceService attribute.");

        return baseService;
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