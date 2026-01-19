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
                    return await HandleBattleOutcome(game);

                case 2:
                    Console.Clear();

                    Console.WriteLine("Cargando partida...");
                    var loadedGame = LoadGame();
                    if (loadedGame == null) return false;

                    Console.WriteLine("Partida cargada.");
                    await ShowRemainingPokemons();

                    PrintWaitForPressKey();

                    StartBattle(loadedGame);

                    return await HandleBattleOutcome(loadedGame);

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

        // ============================
        // POST-BATALLA (centralizado)
        // ============================
        private static async Task<bool> HandleBattleOutcome(GameState game)
        {
            // 1) EMPATE total: ambos a 0
            if (game.PlayerPokemon.Lives <= 0 && game.CpuPokemon.Lives <= 0)
            {
                Console.WriteLine("Empate: Nadie gana esta ronda.");

                SaveGame(game);
                await ShowRemainingPokemons();
                PrintWaitForPressKey();
                return false; // volver al menu
            }

            // 2) VICTORIA: CPU a 0
            if (game.CpuPokemon.Lives <= 0)
            {
                Console.WriteLine("¡Has ganado esta ronda!");
                await DeletePokemonById(game.CpuPokemon.Id);
                
                SaveGame(game);
                
                await ShowRemainingPokemons();
                
                PrintWaitForPressKey();
                return false; // volver al menu
            }

            // 3) DERROTA: jugador a 0
            if (game.PlayerPokemon.Lives <= 0)
            {
                Console.WriteLine("Has perdido esta ronda.");

                // Vida global del jugador (intentos)
                game.PlayerLives--;

                if (game.PlayerLives <= 0)
                {
                    Console.WriteLine("¡GAME OVER! Te quedaste sin vidas.");
                    PrintWaitForPressKey();
                    return true; // FIN REAL DEL JUEGO (sale del bucle principal)
                }

                // Guardamos aunque pierdas (si no, cargar partida no tiene sentido)
                SaveGame(game);
                await ShowRemainingPokemons();
                PrintWaitForPressKey();
                return false; // volver al menu
            }

            // Caso defensivo: no debería pasar si el combate está bien
            Console.WriteLine("Fin de batalla: estado inesperado (nadie llego a 0). Revisa la logica de combate.");
            SaveGame(game);
            PrintWaitForPressKey();
            return false;
        }
    }
}
