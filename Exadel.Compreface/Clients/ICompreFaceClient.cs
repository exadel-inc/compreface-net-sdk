namespace Exadel.Compreface.Clients
{
    public interface ICompreFaceClient
    {
        public T GetService<T>(string apiKey) where T : class;
    }
}
