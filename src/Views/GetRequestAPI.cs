
using System.Text.Json;
using static GamePPT_Api.Program;
using static GamePPT_Api.APIControllers;
using static GamePPT_Api.HttpClientService;
using static GamePPT_Api.Views;


namespace GamePPT_Api
{
    internal class GetRequestAPI
    {

        public static async Task GetPokemons()
        {
            HttpResponseMessage response = await client.GetAsync(BASE_URL);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }

            string json = response.Content.ReadAsStringAsync().Result;
            var GamePPT_Api = JsonDocument.Parse(json).RootElement;

            foreach (var pokemon in GamePPT_Api.EnumerateArray())
            {
                Console.WriteLine(
                    $"\nID: {pokemon.GetProperty("id").GetInt32()}" +
                    $"\nNombre: {pokemon.GetProperty("name").GetString()}" +
                    $"\nTipo: {string.Join(", ", pokemon.GetProperty("type").EnumerateArray().Select(t => t.GetString()))}" +
                    $"\nAltura: {pokemon.GetProperty("height").GetDouble()} mt/s" +
                    $"\nPeso: {pokemon.GetProperty("mass").GetDouble()} kg/s" +
                    $"\nMovimientos: {string.Join(", ", pokemon.GetProperty("moves").EnumerateArray().Select(m => m.GetString()))}"
                );
            }
            PrintWaitForPressKey();
        }
    }
}