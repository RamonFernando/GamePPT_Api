/*
StartBattle(GameState game)
ResolveRound(string player, string cpu)
GetPlayerChoice()
GetCpuChoice()
*/
namespace GamePPT_Api
{
    public static class BattleControllers
    {
        private static readonly Random _rnd = new Random();

        public static void StartBattle(GameState game)
        {
            Console.Clear();
            Console.WriteLine("=== COMIENZA LA BATALLA ===\n");

            // Bucle de combate: termina cuando alguien llega a 0 vidas
            while (game.PlayerPokemon.Lives > 0 && game.CpuPokemon.Lives > 0)
            {
                Console.WriteLine($"{game.PlayerPokemon.Name} (Vidas: {game.PlayerPokemon.Lives}) VS {game.CpuPokemon.Name} (Vidas: {game.CpuPokemon.Lives})\n");

                string playerChoice = GetPlayerChoice();
                string cpuChoice = GetCpuChoice();

                Console.WriteLine($"\nJugador: {playerChoice}");
                Console.WriteLine($"CPU:     {cpuChoice}\n");

                ResolveRound(playerChoice, cpuChoice, game);

                Console.WriteLine($"\nEstado -> {game.PlayerPokemon.Name}: {game.PlayerPokemon.Lives} vidas | {game.CpuPokemon.Name}: {game.CpuPokemon.Lives} vidas");
                Console.WriteLine("\nPulsa una tecla...");
                Console.ReadKey();
                Console.Clear();
            }

            // Resultado final
            if (game.PlayerPokemon.Lives <= 0 && game.CpuPokemon.Lives <= 0)
                Console.WriteLine("Empate total.");
            else if (game.PlayerPokemon.Lives <= 0)
                Console.WriteLine($"Pierdes. Gana {game.CpuPokemon.Name}.");
            else
                Console.WriteLine($"¡Ganas! {game.PlayerPokemon.Name} vence a {game.CpuPokemon.Name}.");
        }

        public static void ResolveRound(string player, string cpu, GameState game)
        {
            // Empate: nadie ataca
            if (player == cpu)
            {
                Console.WriteLine("Empate: nadie ataca.");
                return;
            }

            // Regla piedra-papel-tijera con tus 3 acciones:
            // ataque > defensa
            // defensa > especial
            // especial > ataque
            bool playerWins =
                (player == "ataque" && cpu == "defensa") ||
                (player == "defensa" && cpu == "especial") ||
                (player == "especial" && cpu == "ataque");

            if (playerWins)
            {
                Console.WriteLine("Ganas la ronda: atacas y la CPU pierde 1 vida.");
                game.CpuPokemon.Lives = Math.Max(0, game.CpuPokemon.Lives - 1);
                return;
            }

            Console.WriteLine("Pierdes la ronda: la CPU ataca y pierdes 1 vida.");
            game.PlayerPokemon.Lives = Math.Max(0, game.PlayerPokemon.Lives - 1);
        }

        public static string GetPlayerChoice()
        {
            while (true)
            {
                Console.WriteLine("Elige acción (piedra-papel-tijera):");
                Console.WriteLine("1 - Ataque");
                Console.WriteLine("2 - Defensa");
                Console.WriteLine("3 - Especial");
                Console.Write("> ");

                string? input = Console.ReadLine();

                if (input == "1") return "ataque";
                if (input == "2") return "defensa";
                if (input == "3") return "especial";

                Console.WriteLine("Opción inválida.\n");
            }
        }

        public static string GetCpuChoice()
        {
            string[] options = { "ataque", "defensa", "especial" };
            return options[_rnd.Next(0, options.Length)];
        }

        public static bool IsBattleFinished(GameState game)
        {
            return game.PlayerPokemon.Lives <= 0 || game.CpuPokemon.Lives <= 0;
        }

        public static Pokemon GetLoser(GameState game)
        {
            return game.PlayerPokemon.Lives <= 0
                ? game.PlayerPokemon
                : game.CpuPokemon;
        }
        public static bool PlayerLostRound(GameState game)
        {
            return game.PlayerPokemon.Lives <= 0;
        }



    }
}

