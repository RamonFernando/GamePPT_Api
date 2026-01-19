namespace GamePPT_Api
{
    public static class LoadGameJson
    {
        public static GameState? LoadGame()
        {
            if (!File.Exists("src/json/savegame.json"))
            {
                Console.WriteLine("No hay partida guardada.");
                PrintWaitForPressKey();
                return null;
            }

            var json = File.ReadAllText("src/json/savegame.json");
            var save = JsonSerializer.Deserialize<SaveGame>(json);

            if (save == null) return null;

            var pokemons = GetAllPokemonsAsync().GetAwaiter().GetResult();
            var playerPokemon = pokemons.FirstOrDefault(p => p.Id == save.PlayerPokemonId);

            if (playerPokemon == null)
            {
                Console.WriteLine("El Pokémon del jugador ya no existe.");
                PrintWaitForPressKey();
                return null;
            }

            var cpuPokemon = pokemons[new Random().Next(pokemons.Count)];
            return new GameState
            {
                PlayerLives = save.PlayerLives,
                PlayerPokemon = playerPokemon,
                CpuPokemon = cpuPokemon
            };
        }
    }

}