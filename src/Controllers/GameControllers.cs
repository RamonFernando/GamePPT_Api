/*
NewGame()
LoadGame()
StopNewGame()
 */
namespace GamePPT_Api
{
    public static class GameControllers
    {
        public static async Task<GameState?> NewGame()
        {
            Console.Clear();
            Console.WriteLine("=== NUEVO JUEGO ===\n");

            await ResetApiGame();

            // 1. Cargar pokémons desde API
            List<Pokemon> pokemons = await GetAllPokemonsAsync();

            if (pokemons.Count == 0)
            {
                Console.WriteLine("No se pudieron cargar los Pokémon.");
                PrintWaitForPressKey();
                return null;
            }

            // 2. Mostrar lista
            PrintPokemons(pokemons);

            // 3. Selección jugador
            Pokemon? playerPokemon = SelectPokemon(pokemons);
            if (playerPokemon == null)
            {
                Console.WriteLine("No hay Pokémon disponibles para la CPU.");
                PrintWaitForPressKey();
                return null;
            }

            // 4. Selección CPU (aleatoria)
            Pokemon? cpuPokemon = GetRandomCpuPokemon(pokemons, playerPokemon.Id);

            if (cpuPokemon == null)
            {
                Console.WriteLine("No hay Pokémon disponibles para la CPU.");
                PrintWaitForPressKey();
                return null;
            }

            return new GameState
            {
                PlayerLives = 3,
                PlayerPokemon = playerPokemon,
                CpuPokemon = cpuPokemon
            };
        }

        // Implementacion futura
        public static void StopNewGame()
        {
            Console.WriteLine("Deteniendo nuevo juego...");
            // Lógica para detener un nuevo juego
        }

        private static Pokemon? GetRandomCpuPokemon( List<Pokemon> pokemons, int playerId)
        {
            var available = pokemons
                .Where(p => p.Id != playerId)
                .ToList();

            if (available.Count == 0) return null;

            Random random = new Random();
            return available[random.Next(available.Count)];
        }

        private static async Task ResetApiGame()
        {
            try
            {
                var client = HttpClientService.GetHttpClient();
                await client.PostAsync("/reset", null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al resetear el juego: {ex.Message}");
            }
        }

    }
}