using Exadel.Compreface.Clients.Interfaces;

namespace Exadel.Compreface.Clients.Factories
{
    public abstract class ClientFactory
    {
        public abstract ICompreFaceClient GetClient();
    }
}