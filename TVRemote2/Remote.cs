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
            Console.WriteLine("Enter your command: (0:power, 1:volume up, 2:volume down, 3:channel up, 4:channel down, 5:set channel, 6:mute, 7:settings, 8:smart menu)");
            string button = Console.ReadLine();

            if(button == "7")
            {
                showSettingButtons();
            }
            else if(button == "8")
            {
                showSmartMenuButtons();
            }
            else
            {
                screen.receiver(button); // just send fictional IR Signal to TV Screen
            }

        }

        public void showSettingButtons()
        {
            bool isSetting = true;
            while (isSetting)
            {
                Console.WriteLine("Enter your command: (0:increase brightness, 1:decrease brightness, 2:increase contras, 3:decrease contras, 4:back)");
                string settingButton = Console.ReadLine();

                screen.settingButtonReceiver(settingButton, ref isSetting);
            }
        }

        public void showSmartMenuButtons()
        {
            bool isSmartMenu = true;
            while (isSmartMenu)
            {
                Console.WriteLine("Enter your command: (0:Netflix, 1:Hulu, 2:Prime Video, 3:YouTube, 4:back)");
                string smartMenuButton = Console.ReadLine();

                screen.smartMenuButtonReceiver(smartMenuButton, ref isSmartMenu);

            }
        }
    }
}
