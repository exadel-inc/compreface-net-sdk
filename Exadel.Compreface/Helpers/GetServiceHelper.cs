using Exadel.Compreface.Clients;
using Exadel.Compreface.Services;
using Exadel.Compreface.Services.RecognitionService;

namespace Exadel.Compreface.Helpers
{
    public static class GetServiceHelper
    {
        //public static T GetService<T>(List<T> services, string key)
        //    where T : RecognitionService

        //{
        //    foreach (var servise in services)
        //    {
        //        ApiClient apiClient = (ApiClient)servise._apiClient;
        //        if (apiClient._apiKey == key)
        //            return (T)servise;

        //    }
        //    return null;
        //}



        public static RecognitionService? GetService(List<RecognitionService> services, string key)
        {
            foreach (var servise in services)
            {
                ApiClient apiClient = (ApiClient)servise._apiClient;
                if (apiClient._apiKey == key)
                    return servise;

            }
            return null;
        }
        public static FaceDetectionService? GetService(List<FaceDetectionService> services, string key)
        {
            foreach (var servise in services)
            {
                ApiClient apiClient = (ApiClient)servise._apiClient;
                if (apiClient._apiKey == key)
                    return servise;

            }
            return null;
        }
        public static FaceVerificationService? GetService(List<FaceVerificationService> services, string key)
        {
            foreach (var servise in services)
            {
                ApiClient apiClient = (ApiClient)servise._apiClient;
                if (apiClient._apiKey == key)
                    return servise;

            }
            return null;
        }
    } 
}
