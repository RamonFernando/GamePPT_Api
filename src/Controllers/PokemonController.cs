namespace GamePPT_Api
{
    public static class PokemonController
    {
        public static Pokemon? SelectPokemon(List<Pokemon> pokemons)
        {
            Console.Write("\nElige un Pokémon por ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return null;

            return pokemons.FirstOrDefault(p => p.Id == id);
        }
    }
}