namespace Exadel.Compreface.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string _methodName, string _exceptionMessage) : base(ServiceExceptionMethod(_methodName, _exceptionMessage))
        {
        }

        private static string ServiceExceptionMethod(string methodName, string exceptionMessage) 
        {
            var finalMessage = methodName + " method has thrown exception." + exceptionMessage;

            return finalMessage;
        }
        
    };
}
