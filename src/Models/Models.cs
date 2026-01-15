using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GamePPT_Api
{
    
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public int Lives { get; set; }
        public string Hability { get; set; } = "";

        public static List<Pokemon> pokemonsFavoriteList = new List<Pokemon> ();
    }
    
}
