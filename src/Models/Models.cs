using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GamePPT_Api
{
    
    public class Pokemon
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("type")]
        public string Type { get; set; } = "";

        [JsonPropertyName("lives")]
        public int Lives { get; set; }

        [JsonPropertyName("hability")]
        public string Hability { get; set; } = "";

        public static List<Pokemon> pokemonsFavoriteList = new List<Pokemon> ();
    }

    public class SaveGame
    {
        public int PlayerLives { get; set; }
        public int PlayerPokemonId { get; set; }

    }
    
}
