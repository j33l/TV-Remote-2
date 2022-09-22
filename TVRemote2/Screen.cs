using System;
namespace TVRemote2
{
    public class Screen
    {
        public Screen(String model)
        {
            this.model = model;
        }


        /*
        *  screen state
        */
        private String model;
        private bool power = false;
        private int currentVolume = 50; // 0 to 100
        private int currentChannel = 0;
        private bool mute = false;
        private int brightness = 50;
        private int contras = 50;
        private string onlineStreamingChannel = null; // Netflix, Hulu, etc


        /*
        * setters
        */
        public void changePower()
        {
            this.power = !this.power;
        }

        public void changeVolume(bool increase = true)
        {
            if (increase)
            {
                if (this.currentVolume < 100)
                {
                    this.currentVolume++;
                }
            }
            else
            {
                if (this.currentVolume > 0)
                {
                    this.currentVolume--;
                }
            }
        }

        public void changeChannel(bool increase = true)
        {
            if (increase)
            {
                if (this.currentChannel < 100)
                {
                    this.currentChannel++;
                    this.onlineStreamingChannel = null;
                }
            }
            else
            {
                if (this.currentChannel > 0)
                {
                    this.currentChannel--;
                    this.onlineStreamingChannel = null;
                }
            }
        }

        public void setChannel(int newChannel)
        {
            if (newChannel >= 0 && newChannel <= 100)
            {
                this.currentChannel = newChannel;
                this.onlineStreamingChannel = null;
            }
        }

        public void setOnlineStreamingChannel(string channel)
        {
            this.onlineStreamingChannel = channel;
        }

        public void changeMute()
        {
            this.mute = !this.mute;
        }

        public void changeBrightness (bool increase = true)
        {
            if (increase)
            {
                if (this.brightness < 100)
                {
                    this.brightness++;
                }
            }
            else
            {
                if (this.brightness > 0)
                {
                    this.brightness--;
                }
            }
        }

        public void changeContras(bool increase = true)
        {
            if (increase)
            {
                if (this.contras < 100)
                {
                    this.contras++;
                }
            }
            else
            {
                if (this.contras > 0)
                {
                    this.contras--;
                }
            }
        }


        /*
        * getters
        */
        public bool getPower()
        {
            return this.power;
        }

        public bool getMute()
        {
            return this.mute;
        }

        public int getCurrentVolume()
        {
            return this.currentVolume;
        }

        public String getModel()
        {
            return this.model;
        }

        public string getCurrentChannel()
        {
            return this.onlineStreamingChannel != null ? this.onlineStreamingChannel : this.currentChannel.ToString();
        }

        public int getBrightness()
        {
            return this.brightness;
        }

        public int getContras()
        {
            return this.contras;
        }


        /*
         * TV Remote receiver
         */
        public void receiver(string button)
        {
            switch (button)
            {
                case "0":
                    this.changePower();
                    break;
                case "1":
                    this.changeVolume();
                    break;
                case "2":
                    this.changeVolume(false);
                    break;
                case "3":
                    this.changeChannel();
                    break;
                case "4":
                    this.changeChannel(false);
                    break;
                case "5":
                    Console.WriteLine("Enter your channel number: (0-100)");
                    string channel = Console.ReadLine();
                    this.setChannel(Int32.Parse(channel));
                    break;
                case "6":
                    this.changeMute();
                    break;
                //case "7":
                //    this.settingButtonReceiver();
                //    break;
                //case "8":
                //    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }

        }

        public void settingButtonReceiver(string settingButton, ref bool isSetting)
        {
            
            switch (settingButton)
            {
                case "0":
                    this.changeBrightness();
                    break;
                case "1":
                    this.changeBrightness(false);
                    break;
                case "2":
                    this.changeContras();
                    break;
                case "3":
                    this.changeContras(false);
                    break;
                case "4":
                    isSetting = false;
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }

        public void smartMenuButtonReceiver(string smartMenuButton, ref bool isSmartMenu)
        {
            switch (smartMenuButton)
            {
                case "0":
                    this.setOnlineStreamingChannel("Netflix");
                    break;
                case "1":
                    this.setOnlineStreamingChannel("Hulu");
                    break;
                case "2":
                    this.setOnlineStreamingChannel("Prime Video");
                    break;
                case "3":
                    this.setOnlineStreamingChannel("YouTube");
                    break;
                case "4":
                    isSmartMenu = false;
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}

