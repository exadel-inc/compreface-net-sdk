namespace Exadel.Compreface.Clients.CompreFaceClient
{
    public interface ICompreFaceClient
    {
        public T GetService<T>(string apiKey) where T : class;
    }
}
