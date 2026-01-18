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

            // 1. Cargar pokémons desde API
            List<Pokemon> pokemons = await GetAllPokemonsAsync();

            if (pokemons.Count == 0)
            {
                Console.WriteLine("No se pudieron cargar los Pokémon.");
                return null;
            }

            // 2. Mostrar lista
            PrintPokemons(pokemons);

            // 3. Selección jugador
            Pokemon? playerPokemon = SelectPokemon(pokemons);
            if (playerPokemon == null)
            {
                Console.WriteLine("Selección inválida.");
                return null;
            }

            // 4. Selección CPU (aleatoria)
            Pokemon cpuPokemon = GetRandomCpuPokemon(pokemons, playerPokemon.Id);

            Console.WriteLine($"\nTu Pokémon: {playerPokemon.Name}");
            Console.WriteLine($"CPU Pokémon: {cpuPokemon.Name}");

            return new GameState
            {
                PlayerPokemon = playerPokemon,
                CpuPokemon = cpuPokemon
            };
        }

        public static void StopNewGame()
        {
            Console.WriteLine("Deteniendo nuevo juego...");
            // Lógica para detener un nuevo juego
        }

        private static Pokemon GetRandomCpuPokemon( List<Pokemon> pokemons, int playerId)
        {
            var available = pokemons
                .Where(p => p.Id != playerId)
                .ToList();

            Random random = new Random();
            return available[random.Next(available.Count)];
        }

    }
}