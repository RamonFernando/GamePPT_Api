/*
DeleteAsync
GetHttpClient
HandleHttpError(Exception ex)
 */
namespace GamePPT_Api
{
    internal class HttpClientService
    {
        public static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:4000"),
            Timeout = TimeSpan.FromSeconds(10)
        };

        public static HttpClient GetHttpClient() => client;

        public static async Task<bool> DeleteAsync(string endpoint)
        {
            try
            {
                var response = await client.DeleteAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error DELETE -> {(int)response.StatusCode} {response.ReasonPhrase}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DELETE: {ex.Message}");
                return false;
            }
        }
    }
}
