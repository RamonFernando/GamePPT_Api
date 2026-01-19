/*
ReadOption()
HandlerOption(int option)
*/
namespace GamePPT_Api
{
    public class AppController
    {
        

        public static int ReadOption()
        {
            string? input = Console.ReadLine();
            return !int.TryParse(input, out var option) ? -1 : option;
        }
        
        public static async Task<bool> HandlerOption(int option)
        {
            switch (option)
            {
                case 1:
                    var game = await NewGame();
                    if (game == null) return false;

                    StartBattle(game);

                    // VICTORIA (CPU llegó a 0)
                    if (game.CpuPokemon.Lives <= 0)
                    {
                        Console.WriteLine("¡Has ganado esta ronda!");
                        await DeletePokemonById(game.CpuPokemon.Id);
                        SaveGame(game);
                        await ShowRemainingPokemons();
                        PrintWaitForPressKey();
                        break;
                    }

                    // DERROTA (Jugador llegó a 0)
                    game.PlayerLives--;

                    if (game.PlayerLives <= 0)
                    {
                        Console.WriteLine("¡GAME OVER!");
                        PrintWaitForPressKey();
                        return false;
                    }

                    Console.WriteLine("Has perdido esta ronda.");
                    PrintWaitForPressKey();
                    return false;

                case 2:
                    Console.Clear();
                    
                    Console.WriteLine("Cargando partida...");
                    var loadedGame = LoadGame();
                    if (loadedGame == null) return false;

                    Console.WriteLine("Partida cargada.");
                    await ShowRemainingPokemons();
                    
                    PrintWaitForPressKey();

                    StartBattle(loadedGame);
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Lista de Pokemons restantes:");
                    await ShowRemainingPokemons();
                    PrintWaitForPressKey();
                    break;

                case 0:
                    Console.WriteLine("\nSaliendo del programa...");
                    Environment.Exit(0);
                    return true;
                default:
                    Console.WriteLine("Opción no válida, por favor ingresa un número entre 0 y 3.");
                    PrintWaitForPressKey();
                    break;
            }
            return false;
        }
    }
}