using System.Text.Json;

using static pokeAPI.Program;
using static pokeAPI.Views;
using static pokeAPI.SavePokemonList;
using static pokeAPI.Helpers;


namespace pokeAPI
{
    public class APILoadJson
    {
        public static void APILoadFavoriteList()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "favoriteListPoke.json");

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("El archivo no existe. Se creara uno nuevo.");
                    File.WriteAllText(filePath, JsonSerializer.Serialize(new List<Pokemon>()));
                    PrintWaitForPressKey();
                    return;
                }

                var json = File.ReadAllText(filePath);

                File.WriteAllText(filePath, json);
                pokemonsFavoriteList = JsonSerializer.Deserialize<List<Pokemon>>(json) ?? new List<Pokemon>();

                if (pokemonsFavoriteList == null)
                {
                    pokemonsFavoriteList = new List<Pokemon>();
                    Console.WriteLine("No se pudo cargar la lista de favoritos. Se creo una nueva.");
                    if(pokemonsFavoriteList.Count == 0) return;
                    PrintWaitForPressKey();
                    return;
                }
            }
            catch (Exception ex)
            {
                HandlerException(ex);
                PrintWaitForPressKey();
            }
        }
    }
}