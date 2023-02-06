using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services.Interfaces;

namespace Exadel.Compreface.Clients;

/// <summary>
/// Wrapper on top of Flurl.Http package's extension methods
/// </summary>
public class CompreFaceClient : ICompreFaceClient
{
    private readonly string _domain;
    private readonly string _port;

    //private readonly Dictionary<ServiceDictionaryKey, IBaseService> _services = new();

    public CompreFaceClient(IComprefaceConfiguration configuration)
        : this(configuration.Domain, configuration.Port) { }

    public CompreFaceClient(string domain, string port)
    {
        _domain = domain;
        _port = port;
    }

    public T GetService<T>(string apiKey) where T : class
    {
        //var key = new ServiceDictionaryKey(apiKey, typeof(T));
        //var baseService = _services.GetValueOrDefault(key);

        //if (baseService == null)
        //{
            var config = new ComprefaceConfiguration(apiKey, _domain, _port);
            
            var baseService = GetBaseService(typeof(T), config);

            //_services.Add(key, baseService!);
        //}

        return (baseService as T)!;
    }

    private object GetBaseService(Type type, ComprefaceConfiguration config)
    {
        try { 
        object service = null;
        if (type.GetInterface(nameof(IBaseService)) != null)
            service = Activator.CreateInstance(type, config);
        return service;
        }
        catch(NullReferenceException ex) 
        {
            throw new NullReferenceException();
        }
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