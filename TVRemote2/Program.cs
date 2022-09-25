using System;

namespace TVRemote2
{
    class Program
    {

        /*
         * Monitoring TV screen State changes
         */
        static void getScreenStatus(Screen screen)
        {
            if(screen.IsError)
            {
                changeConsoleColor(screen.IsError);
            }
            
            Console.WriteLine("TV Screen State: ");
            Console.WriteLine($"#########################\n# Model: {screen.Model} \t\t#\n# Power: {screen.Power} \t\t#\n# Volume: {screen.CurrentVolume} \t\t#\n# Channel: {screen.getCurrentChannel()} \t\t#\n# Mute: {screen.Mute} \t\t#\n# Settings: {screen.IsSetting} \t\t#\n# SmartMenu: {screen.IsSmartMenu} \t\t#\n# Brightness: {screen.Brightness} \t#\n# Contras: {screen.Contras} \t\t#\n#########################");
        }

        static void changeConsoleColor(bool isError)
        {
            if(isError)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        

        static void Main(String[] args)
        {
            Console.WriteLine("Enter your TV Model: (75TU7000)");
            string model = Console.ReadLine();

            TVRemote2.Screen screen = new TVRemote2.Screen(model);
            TVRemote2.Remote remote = new TVRemote2.Remote(ref screen);

            

            /*
             * Interacting with Remote
             */
            do
            {
                remote.showButtons();
                Console.Clear(); // clearing previous outputs
                getScreenStatus(screen);

                // normalizing after Error
                screen.IsError = false;
                changeConsoleColor(false);


            } while (screen.Power);

        }

    }


}
