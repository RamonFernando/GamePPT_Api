/*
PlayerPokemon
CpuPokemon
 */
namespace GamePPT_Api
{
    public class GameState
    {
            public Pokemon PlayerPokemon { get; set; } = null!;
            public Pokemon CpuPokemon { get; set; } = null!;

            public int PlayerLives { get; set; } = 3;
    }
}