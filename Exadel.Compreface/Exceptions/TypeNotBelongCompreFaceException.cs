namespace Exadel.Compreface.Exceptions
{
    public class TypeNotBelongCompreFaceException : Exception
    {
        public TypeNotBelongCompreFaceException()
        { }

        public TypeNotBelongCompreFaceException(string message)
            : base(message)
        { }

        public TypeNotBelongCompreFaceException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
