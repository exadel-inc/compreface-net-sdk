using Exadel.Compreface.Configuration;
using Exadel.Compreface.Exceptions;
using Exadel.Compreface.Services.Attributes;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Exadel.Compreface.Clients.CompreFaceClient;

/// <summary>
/// Wrapper on top of Flurl.Http package's extension methods
/// </summary>
public class CompreFaceClient : ICompreFaceClient
{
    private readonly string _domain;
    private readonly string _port;

    private readonly Dictionary<ServiceDictionaryKey, object> _services = new();

    public CompreFaceClient(string? domain, string? port)
    {
        _domain = domain ?? throw new ArgumentNullException($"{nameof(domain)} cannot be null!");
        _port = port ?? throw new ArgumentNullException($"{nameof(port)} cannot be null!");
    }

    public CompreFaceClient(IConfiguration configuration, string? domainSection, string? portSection)
    {
        _domain = configuration.GetSection(domainSection).Value ?? throw new ArgumentNullException($"{nameof(domainSection)} cannot be null!");
        _port = configuration.GetSection(portSection).Value ?? throw new ArgumentNullException($"{nameof(portSection)} cannot be null!");
    }

    public T GetCompreFaceService<T>(string apiKey) where T : class
    {
        var compreFaceService = GetService(apiKey, typeof(T));

        return (T)compreFaceService;
    }

    public T GetCompreFaceService<T>(IConfiguration configuration, string apiKeySection) where T : class
    {

        var apiKey = configuration.GetSection(apiKeySection).Value ?? throw new ArgumentNullException($"{nameof(apiKeySection)} cannot be null!");
        var compreFaceService = GetService(apiKey, typeof(T));

        return (T)compreFaceService;
    }

    private object GetService(string apiKey, Type type)
    {
        try
        {
            var key = new ServiceDictionaryKey(apiKey, type);
            var baseService = _services.GetValueOrDefault(key);

            if (baseService == null)
            {
                var config = new ComprefaceConfiguration(apiKey, _domain, _port);
                var apiClient = new ApiClient.ApiClient(config);  
                baseService = ReturnServiceIfTypeIsValid(type, config, apiClient);

                _services.Add(key, baseService!);
            }

            return baseService;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private object ReturnServiceIfTypeIsValid(Type type, ComprefaceConfiguration config, ApiClient.ApiClient apiClient)
    {
        object baseService = null;

        if (type.GetCustomAttribute(typeof(CompreFaceService)) != null)
            baseService = Activator.CreateInstance(type, config, apiClient);

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