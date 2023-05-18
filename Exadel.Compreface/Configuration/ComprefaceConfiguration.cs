using System;

namespace Exadel.Compreface.Configuration
{
    /// <summary>
    /// Setups main parameters for the CompreFace API.
    /// </summary>
    public class ComprefaceConfiguration : IComprefaceConfiguration
    {
        public string Domain { get; set; }

        public string Port { get; set; }

        public string ApiKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey">Api key of a service from CompreFace.</param>
        /// <param name="domain">Domain with protocol where CompreFace is located.</param>
        /// <param name="port">CompreFace port.</param>
        /// <exception cref="ArgumentNullException">Is throwed if one of the parameters is null.</exception>
        public ComprefaceConfiguration(string apiKey, string domain, string port)
        {
            Domain = domain ?? throw new ArgumentNullException($"{nameof(domain)} cannot be null!");
            Port = port ?? throw new ArgumentNullException($"{nameof(port)} cannot be null!");
            ApiKey = apiKey ?? throw new ArgumentNullException($"{nameof(apiKey)} cannot be null!");
        }
    }
}