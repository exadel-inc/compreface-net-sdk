using Exadel.Compreface.Clients.Interfaces;

namespace Exadel.Compreface.Clients
{
    public class Client
    {
        private IEnumerable<IApiClient> _clients;
        public Client(IEnumerable<IApiClient> clients)
        {
            _clients = clients;
        }

        public IApiClient? GetBarByKey(string key)
        {
            foreach(ApiClient client in _clients)
            {
                if(client._apiKey == key) return client;
                
            }
            return null;
        }
    }
}
