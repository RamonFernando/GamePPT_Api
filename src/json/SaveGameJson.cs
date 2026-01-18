namespace GamePPT_Api
{
    public class SaveGameJson
    {
        public static void SaveGame(GameState game)
        {
            var save = new SaveGame
            {
                PlayerLives = game.PlayerLives,
                PlayerPokemonId = game.PlayerPokemon.Id
            };

            var json = JsonSerializer.Serialize(save, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("src/json/savegame.json", json);

            Console.WriteLine("Partida guardada correctamente.");
        }
    }

}