namespace GamePPT_Api
{
    class PokemonApiServices
    {
        public static async Task<List<Pokemon>> GetAllPokemonsAsync()
        {
            try
            {

                var json = await client.GetStringAsync(BASE_URL);


                return JsonSerializer.Deserialize<List<Pokemon>>(json) ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cargando pokemons: {ex.Message}");
                return new();
            }
        }

        public static async Task DeletePokemonById(int id)
        {
            var response = await DeleteAsync($"/pokemons/{id}");

            if (!response)
                Console.WriteLine("Error eliminando el Pokémon.");
        }
    }
}
