
namespace GamePPT_Api
{
    public class App
    {
        public static async Task Run()
        {
            bool exist = false;
            
            while (!exist)
            {
                ShowMainMenu();
                int option = ReadOption();
                exist = await HandlerOption(option);
            }
        }
    }
}