namespace GamePPT_Api
{
    public class GameStates
    {
        public class GameState
        {
            public Pokemon PlayerPokemon { get; set; } = null!;
            public Pokemon CpuPokemon { get; set; } = null!;
        }

    }
}