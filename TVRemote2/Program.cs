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
            Console.WriteLine("TV Screen State: ");
            Console.WriteLine($"#########################\n# Model: {screen.getModel()} \t\t#\n# Power: {screen.getPower()} \t\t#\n# Volume: {screen.getCurrentVolume()} \t\t#\n# Channel: {screen.getCurrentChannel()} \t\t#\n# Mute: {screen.getMute()} \t\t#\n# Brightness: {screen.getBrightness()} \t#\n# Contras: {screen.getContras()} \t\t#\n#########################");
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
            while (screen.getPower())
            {
                remote.showButtons();
                getScreenStatus(screen);
            }

        }

    }


}
