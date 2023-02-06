namespace Exadel.Compreface.Services.Attributes
{
    /// <summary>
    /// Tag for CompreFace services to open ability call them from client.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CompreFaceService : Attribute
    {
    }
}
