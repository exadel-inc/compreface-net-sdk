using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Exadel.Compreface.AcceptenceTests")]
[assembly: InternalsVisibleTo("Exadel.Compreface.UnitTests")]
namespace Exadel.Compreface.Services.Attributes
{
    /// <summary>
    /// Tag for CompreFace services to open ability call them from client.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class CompreFaceService : Attribute
    {
    }
}