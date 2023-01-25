using Exadel.Compreface.Clients.Config;
using Exadel.Compreface.Clients.Interfaces;
using Exadel.Compreface.Configuration;

namespace Exadel.Compreface.Services
{
    public abstract class AbstractBaseService
    {
        protected IComprefaceConfiguration Configuration { get; private set; }

        protected IApiClient ApiClient { get; private set; }

        public AbstractBaseService(IComprefaceConfiguration configuration, IApiClient apiClient)
        {
            Configuration = configuration;
            ApiClient = apiClient;

            ConfigInitializer.InitializeSnakeCaseJsonConfigs();
        }
    }
}
