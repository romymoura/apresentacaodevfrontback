using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace Apresentacao.Business.Services.Integration.Bases
{
    public abstract class BasesAPI : BaseIDispose
    {
        public HttpClient _client = null;
        public IConfiguration Configuration { get; }
        public static string UrlApi;
        public BasesAPI(IConfiguration configuration)
        {
            Configuration = configuration;
            UrlApi = Configuration.GetSection("AppConfiguration")["apiUrl"];
        }
        public BasesAPI()
        {
        }

        #region Destructor
        ~BasesAPI()
        {
            this.Dispose();
        }
        #endregion
    }
}
