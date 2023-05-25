using System.IO;
using System.Text.Json;
using Flurl.Http.Configuration;

namespace Exadel.Compreface.Helpers
{

    public class SystemJsonSerializer : ISerializer
    {
        private readonly JsonSerializerOptions _options;

        public SystemJsonSerializer(JsonSerializerOptions options = null)
        {
            _options = options;
        }

        public T Deserialize<T>(string s)
        {
            return JsonSerializer.Deserialize<T>(s, _options);
        }

        public T Deserialize<T>(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                return Deserialize<T>(reader.ReadToEnd());
            }
        }

        public string Serialize(object obj)
        {
            return JsonSerializer.Serialize(obj, _options);
        }
    }
}