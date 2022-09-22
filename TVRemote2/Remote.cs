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

        //static void Main(String[] args)
        //{
        //    Console.WriteLine("This is TV Remote Controller.");
        //}

        /*
        *  remote state
        */
        String model;

        // tv screen deligates here
        Screen screen;

        public void showButtons()
        {
            Console.WriteLine("Enter your command: (0:power, 1:volume up, 2:volume down, 3:channel up, 4:channel down, 5:set channel, 6:mute, 7:settings, 8:smart menu)");
            string button = Console.ReadLine();

            switch (button)
            {
                case "0":
                    this.screen.changePower();
                    break;
                case "1":
                    this.screen.changeVolume();
                    break;
                case "2":
                    this.screen.changeVolume(false);
                    break;
                case "3":
                    this.screen.changeChannel();
                    break;
                case "4":
                    this.screen.changeChannel(false);
                    break;
                case "5":
                    Console.WriteLine("Enter your channel number: (0-100)");
                    string channel = Console.ReadLine();
                    this.screen.setChannel(Int32.Parse(channel));
                    break;
                case "6":
                    this.screen.changeMute();
                    break;
                case "7":
                    bool isSetting = true;
                    while(isSetting)
                    {
                        Console.WriteLine("Enter your command: (0:increase brightness, 1:decrease brightness, 2:increase contras, 3:decrease contras, 4:back)");
                        string settingButton = Console.ReadLine();
                        switch (settingButton)
                        {
                            case "0":
                                this.screen.changeBrightness();
                                break;
                            case "1":
                                this.screen.changeBrightness(false);
                                break;
                            case "2":
                                this.screen.changeContras();
                                break;
                            case "3":
                                this.screen.changeContras(false);
                                break;
                            case "4":
                                isSetting = false;
                                break;
                            default:
                                Console.WriteLine("Invalid command.");
                                break;
                        }
                    }
                    break;
                case "8":
                    bool isSmartMenu = true;
                    while (isSmartMenu)
                    {
                        Console.WriteLine("Enter your command: (0:Netflix, 1:Hulu, 2:Prime Video, 3:YouTube, 4:back)");
                        string settingButton = Console.ReadLine();
                        switch (settingButton)
                        {
                            case "0":
                                this.screen.setOnlineStreamingChannel("Netflix");
                                break;
                            case "1":
                                this.screen.setOnlineStreamingChannel("Hulu");
                                break;
                            case "2":
                                this.screen.setOnlineStreamingChannel("Prime Video");
                                break;
                            case "3":
                                this.screen.setOnlineStreamingChannel("YouTube");
                                break;
                            case "4":
                                isSmartMenu = false;
                                break;
                            default:
                                Console.WriteLine("Invalid command.");
                                break;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
