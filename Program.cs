
namespace GamePPT_Api
{
    public class Program
    {
        public static string BASE_URL = "http://localhost:4000/pokemons";
        public static string NameApi => "Piedra, Papel o Tijera - Pokemon Edition";
        
        static async Task Main(string[] args)
        {
            await App.Run();
            
        } // Main
        
    }
}