/*
DeleteAsync
GetHttpClient
HandleHttpError(Exception ex)
 */
namespace GamePPT_Api
{
    internal class HttpClientService
    {
        public static readonly HttpClient client = new HttpClient();

        public static HttpClient GetHttpClient() => client;

        public static async Task<bool> DeleteAsync(string endpoint)
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(Program.BASE_URL);

                var response = await client.DeleteAsync(endpoint);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DELETE: {ex.Message}");
                return false;
            }
        }

    }

    
}