// views y helpers
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
                    await NewGame();
                    break;
                case 2:
                    // LoadGame();
                    break;
                case 0:
                    Console.WriteLine("\nSaliendo del programa...");
                    Environment.Exit(0);
                    return true;
                default:
                    Console.WriteLine("Opción no válida, por favor ingresa un número entre 0 y 2.");
                    PrintWaitForPressKey();
                    break;
            }
            return false;
        }
    }
}