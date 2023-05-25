namespace Exadel.Compreface.Configuration
{
    public interface IComprefaceConfiguration
    {
        string Domain { get; }

        string Port { get; }

        string ApiKey { get; }
    }
}