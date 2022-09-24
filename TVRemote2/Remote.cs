using System;
using System.Threading;

namespace TVRemote2
{
    public class Remote
    {
        
        public Remote(ref Screen screen)
        {
            this.model = screen.getModel();
            this.screen = screen;
        }

        /*
        *  remote state
        */
        String model;

        Screen screen;

        public void showButtons()
        {
            Console.WriteLine("Enter your command: \n(0:power, 1:volume up, 2:volume down, 3:channel up, 4:channel down, 5:set channel, 6:mute, 7:settings, 8:smart menu) \n Setting Buttons: (70:increase brightness, 71:decrease brightness, 72:increase contras, 73:decrease contras, 74:back) [press 7 to use Settings] \n Smart Menu Buttons (80:Netflix, 81:Hulu, 82:Prime Video, 83:YouTube, 84:back) [press 8 to use Smart Menu]");
            string button = Console.ReadLine();

            
            screen.receiver(button); // just send fictional IR Signal to TV Screen

        }
    }
}
