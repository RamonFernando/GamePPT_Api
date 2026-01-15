using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static GamePPT_Api.Program;
using static GamePPT_Api.APIControllers;
using static GamePPT_Api.Helpers;



namespace GamePPT_Api
{
    internal class Views
    {
        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("**=======================================**");
            Console.WriteLine($" {NameApi}");
            Console.WriteLine("===========================================");
            Console.WriteLine("         MENU PRINCIPAL");
            Console.WriteLine("===========================================");
            Console.WriteLine("1. Nuevo juego");
            Console.WriteLine("2. Cargar juego");
            Console.WriteLine("0. Salir");
            Console.WriteLine("**=======================================**");
            Console.Write("Introduce una opcion: ");
        }

        public static void PrintWaitForPressKey()
        {
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey(); // true para no mostrar la tecla presionada
        }
        public static void PrintMenuOptions(){
            Console.Write("\nDesea agregar a la lista de favoritos? (S/N)");
            string? opc = Console.ReadLine();
            opc = opc?.Trim().ToLower();
            
            if(string.IsNullOrWhiteSpace(opc) || opc != "s")
            {

                Console.WriteLine("Pokemon no agregado a la lista de favoritos.");
                PrintWaitForPressKey();
                return;
            }
            // Console.WriteLine("Pokemon agregado a la lista de favoritos");
            // PrintWaitForPressKey();
            // return;
        }

        // Mostrar 1 solo pokemon
        public static void PrintPokemons(List<Pokemon> pokemons)
        {
            foreach (var p in pokemons)
            {
                Console.WriteLine(
                    $"{p.Id}. {p.Name} | Tipo: {p.Type} | Vidas: {p.Lives}"
                );
            }
        }


        // Mostrar lista de favoritos
        /*public static void PrintFavoriteList()
        {
            if (pokemonsFavoriteList.Count == 0)
            {
                Console.WriteLine("No hay Pokemons en la lista de favoritos.");
                PrintWaitForPressKey();
                return;
            }
            Console.WriteLine($"\nLista de Pokemons Favoritos: {pokemonsFavoriteList.Count}");
            Console.WriteLine("=========================================");
            
            for (int i = 0; i < pokemonsFavoriteList.Count; i++)
            {
                var pokemon = pokemonsFavoriteList[i];
                Console.WriteLine(
                $"\n{i+1}º Pokemon: " +
                $"\n--------------------------" +
                $"\nId: {pokemon.Id}" +
                $"\nNombre: {pokemon.Name}" +
                $"\nTipo: {string.Join(", ", pokemon.Type)}" +
                $"\nAltura: {pokemon.Height} Mt" +
                $"\nPeso: {pokemon.Mass} Kg" +
                $"\nMovimientos: {string.Join(", ", pokemon.Moves)}"
                );
            }
            PrintWaitForPressKey();
        }*/
        
    }
}