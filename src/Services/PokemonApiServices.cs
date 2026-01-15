namespace GamePPT_Api
{
    class PokemonApiServices
    {
        public static async Task<List<Pokemon>> GetPokemonsAsync()
        {
            using HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(Program.BASE_URL);
            return JsonSerializer.Deserialize<List<Pokemon>>(json) ?? new();
        }

    }
}