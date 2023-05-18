using System;
using System.Collections.Generic;
using Exadel.Compreface.Configuration;
using Exadel.Compreface.Exceptions;
using Exadel.Compreface.Services.Attributes;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Exadel.Compreface.Helpers;

namespace Exadel.Compreface.Clients.CompreFaceClient
{
    /// <summary>
    /// Global CompreFace provider.
    /// </summary>
    public class CompreFaceClient : ICompreFaceClient
    {
        private readonly string _domain;
        private readonly string _port;

        private readonly Dictionary<ServiceDictionaryKey, object>
            _services = new Dictionary<ServiceDictionaryKey, object>();

        /// <summary>
        /// Constructor for string parameters.
        /// </summary>
        /// <param name="domain">Domain with protocol where CompreFace is located.</param>
        /// <param name="port">CompreFace port.</param>
        /// <exception cref="ArgumentNullException">Is throwed if one of the parameters is null.</exception>
        public CompreFaceClient(string domain, string port)
        {
            _domain = domain ?? throw new ArgumentNullException($"{nameof(domain)} cannot be null!");
            _port = port ?? throw new ArgumentNullException($"{nameof(port)} cannot be null!");
        }

        /// <summary>
        /// Constructor allows to setup CompreFaceClient from appsettings.json.
        /// </summary>
        /// <param name="configuration">IConfiguration object.</param>
        /// <param name="domainSection">Name of the section for domain parameter in an appsetting.json file.</param>
        /// <param name="portSection">Name of the section for port parameter in an appsetting.json file.</param>
        /// <exception cref="ArgumentNullException">Is throwed if one of the sections in appseting.json doesn't have a value.</exception>
        public CompreFaceClient(IConfiguration configuration, string domainSection, string portSection)
        {
            _domain = configuration.GetSection(domainSection).Value ??
                      throw new ArgumentNullException($"{nameof(domainSection)} cannot be null!");
            _port = configuration.GetSection(portSection).Value ??
                    throw new ArgumentNullException($"{nameof(portSection)} cannot be null!");
        }

        /// <summary>
        /// Creates instance of the service.
        /// </summary>
        /// <typeparam name="T">Type of the service.</typeparam>
        /// <param name="apiKey">Api key string from CompreFace.</param>
        /// <exception cref="TypeNotBelongCompreFaceException">Is throwed if T doesn't belong to CompreFace services.</exception>
        /// <example>var faceVerificationService = client.GetCompreFaceService<VerificationService>("00000000-0000-0000-0000-000000000004")</example>
        /// <returns>Service instance.</returns>
        public T GetCompreFaceService<T>(string apiKey) where T : class
        {
            var compreFaceService = GetService(apiKey, typeof(T));

            return (T)compreFaceService;
        }

        /// <summary>
        /// Creates instance of the service with api key from appsettings.json file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configuration">IConfiguration object.</param>
        /// <param name="apiKeySection">Name of the section for api key parameter in an appsetting.json file.</param>
        /// <exception cref="TypeNotBelongCompreFaceException">Is throwed if T doesn't belong to CompreFace services.</exception>
        /// <exception cref="ArgumentNullException">Is throwed if api key section in appseting.json doesn't have a value.</exception>
        /// <returns>Service instance.</returns>
        public T GetCompreFaceService<T>(IConfiguration configuration, string apiKeySection) where T : class
        {

            var apiKey = configuration.GetSection(apiKeySection).Value ??
                         throw new ArgumentNullException($"{nameof(apiKeySection)} cannot be null!");
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

                    _services.Add(key, baseService);
                }

                return baseService;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private object ReturnServiceIfTypeIsValid(Type type, ComprefaceConfiguration config,
            ApiClient.ApiClient apiClient)
        {
            object baseService = null;

            if (type.GetCustomAttribute(typeof(CompreFaceService)) != null)
                baseService = Activator.CreateInstance(type, config, apiClient);

            if (baseService == null)
                throw new TypeNotBelongCompreFaceException(
                    "Type doesn't belong to CompreFace services. Class should be covered by CompreFaceService attribute.");

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
}