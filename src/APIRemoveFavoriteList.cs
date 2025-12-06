
using static pokeAPI.Program;
using static pokeAPI.APIControllers;
using static pokeAPI.Views;
using static pokeAPI.SavePokemonList;
using static pokeAPI.APILoadJson;
using static pokeAPI.APISaveJson;

namespace pokeAPI
{
    public class APIRemoveFavoriteList
    {

        public static void RequestRemoveFavoriteList()
        {
            Console.WriteLine("Introduce el id del pokemon a borrar: ");
            string? input = Console.ReadLine();
            int id = ValidateInput(input);
            if (id == -1 || id <= 0)
            {
                Console.WriteLine("Id no valido o inexistente.");
                PrintWaitForPressKey();
                return;
            }
            Console.Write($"\nEstas seguro que deseas borrar el pokemon con Id: '{id}' de la lista de favoritos? (S/N): ");
            string? opc = Console.ReadLine();
            opc = opc?.Trim().ToLower();
            
            if(string.IsNullOrWhiteSpace(opc) || opc != "s")
            {
                Console.WriteLine($"Pokemon con ID {id} no borrado de la lista de favoritos.");
                PrintWaitForPressKey();
                return;
            }
            RemoveFavoriteList(id);
            APISaveFavoriteList();
            PrintWaitForPressKey();
        }

        private static void RemoveFavoriteList(int id)
        {
            if (pokemonsFavoriteList.Count == 0)
            {
                Console.WriteLine("No hay Pokemons en la lista de favoritos.");
                PrintWaitForPressKey();
                return;
            }
            if (!pokemonsFavoriteList.Any(pkm => pkm != null && pkm.Id == id))
            {
                Console.WriteLine($"No se encontro ningun Pokemon con el ID: {id}.");
                PrintWaitForPressKey();
                return;
            }
            pokemonsFavoriteList.RemoveAll(pkm => pkm != null && pkm.Id == id);
            Console.WriteLine($"Pokemon con ID {id} borrado de la lista de favoritos.");
            PrintWaitForPressKey();
            return;
        }
    }
}