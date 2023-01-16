namespace Exadel.Compreface.Configuration;

public interface IComprefaceConfiguration
{
    public string Domain { get; }

    public string Port { get; }

    public string ApiKey { get; }
}