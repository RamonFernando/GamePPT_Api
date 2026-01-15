
namespace GamePPT_Api
{
    internal class HttpClientService
    {
        public static readonly HttpClient client = new HttpClient();

        public static HttpClient GetHttpClient() => client;
    }
}