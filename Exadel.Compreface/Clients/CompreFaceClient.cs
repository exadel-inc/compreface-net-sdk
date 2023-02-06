﻿using Exadel.Compreface.Configuration;
using Exadel.Compreface.Services;

namespace Exadel.Compreface.Clients;

/// <summary>
/// Wrapper on top of Flurl.Http package's extension methods
/// </summary>
public class CompreFaceClient
{
    private readonly string _domain;
    private readonly string _port;

    private readonly Dictionary<ServiceDictionaryKey, AbstractBaseService> _services = new();

    public CompreFaceClient(IComprefaceConfiguration configuration)
        : this(configuration.Domain, configuration.Port) { }

    public CompreFaceClient(string? domain, string? port)
    {
        _domain = domain ?? throw new ArgumentNullException($"{nameof(domain)} cannot be null!");
        _port = port ?? throw new ArgumentNullException($"{nameof(port)} cannot be null!");
    }

    public T GetService<T>(string apiKey) where T : AbstractBaseService
    {
        var key = new ServiceDictionaryKey(apiKey, typeof(T));
        var baseService = _services.GetValueOrDefault(key);

        if (baseService == null)
        {
            var config = new ComprefaceConfiguration(key.ApiKey, _domain, _port);
            baseService = Activator.CreateInstance(typeof(T), config) as T;

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