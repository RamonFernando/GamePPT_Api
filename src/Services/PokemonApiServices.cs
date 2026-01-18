namespace GamePPT_Api
{
    class PokemonApiServices
    {
        public static async Task<List<Pokemon>> GetAllPokemonsAsync()
        {
            using HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(Program.BASE_URL);
            return JsonSerializer.Deserialize<List<Pokemon>>(json) ?? new();
        }

        public static async Task DeletePokemonById(int id)
        {
            var response = await DeleteAsync($"/pokemons/{id}");

            if (!response)
                Console.WriteLine("Error eliminando el Pokémon.");
        }

    }
}