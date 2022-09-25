using System;
namespace TVRemote2
{
    public class Screen
    {
        public Screen(String model)
        {
            this.model = model;
        }

        ~Screen()
        {
            Console.WriteLine("Turning Off...");
        }


        /*
        *  screen state
        */
        private String model;
        public String Model
        {
            get => this.model;
        }


        private bool power = false;
        public bool Power
        {
            get => this.power;
            set => this.power = value;
        }
        public void changePower()
        {
            this.Power = !this.Power;
        }


        private int currentVolume = 50; // 0 to 100
        public int CurrentVolume
        {
            get => this.currentVolume;
            set => this.currentVolume = value;
        }
        public void changeVolume(bool increase = true)
        {
            if (increase && this.CurrentVolume < 100)
            {
                this.CurrentVolume++;
            }
            else if (this.CurrentVolume > 0)
            {
                this.CurrentVolume--;
            }
        }


        private int currentChannel = 0;
        public int CurrentChannel
        {
            get => this.currentChannel;
            set => this.currentChannel = value;
        }
        public void changeChannel(bool increase = true)
        {
            if (increase && this.CurrentChannel < 100)
            {
                this.CurrentChannel++;
                this.OnlineStreamingChannel = null;
            }
            else if (!increase && this.CurrentChannel > 0)
            {
                this.CurrentChannel--;
                this.OnlineStreamingChannel = null;
            }
        }
        public void setChannel(int newChannel)
        {
            if (newChannel >= 0 && newChannel <= 100)
            {
                this.CurrentChannel = newChannel;
                this.OnlineStreamingChannel = null;
            }
        }
        public string getCurrentChannel()
        {
            return this.OnlineStreamingChannel != null ? this.onlineStreamingChannel : this.currentChannel.ToString();
        }


        private bool mute = false;
        public bool Mute
        {
            get => this.mute;
            set => this.mute = value;
        }
        public void changeMute()
        {
            this.Mute = !this.Mute;
        }


        private int brightness = 50;
        public int Brightness
        {
            get => this.brightness;
            set => this.brightness = value;
        }
        public void changeBrightness(bool increase = true)
        {
            if (increase && this.Brightness < 100)
            {
                this.Brightness++;
            }
            else if (!increase && this.Brightness > 0)
            {
                this.Brightness--;
            }
        }


        private int contras = 50;
        public int Contras
        {
            get => this.contras;
            set => this.contras = value;
        }
        public void changeContras(bool increase = true)
        {
            if (increase && this.Contras < 100)
            {
                this.Contras++;
            }
            else if (!increase && this.Contras > 0)
            {
                this.Contras--;
            }
        }


        private string onlineStreamingChannel = null; // Netflix, Hulu, etc
        public string OnlineStreamingChannel
        {
            get => this.onlineStreamingChannel;
            set => this.onlineStreamingChannel = value;
        }


        private bool isSetting = false;
        public bool IsSetting
        {
            get => this.isSetting;
            set => this.isSetting = value;
        }


        private bool isSmartMenu = false;
        public bool IsSmartMenu
        {
            get => this.isSmartMenu;
            set => this.isSmartMenu = value;
        }


        private bool isError = false;
        public bool IsError
        {
            get => this.isError;
            set => this.isError = value;
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
                case "7":
                    this.IsSetting = true;
                    break;
                case "70":
                    if (this.IsSetting)
                    {
                        this.changeBrightness();
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "71":
                    if (this.IsSetting)
                    {
                        this.changeBrightness(false);
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "72":
                    if (this.IsSetting)
                    {
                        this.changeContras();
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "73":
                    if (this.IsSetting)
                    {
                        this.changeContras(false);
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "74":
                    if (this.IsSetting)
                    {
                        this.IsSetting = false;
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "8":
                    this.IsSmartMenu = true;
                    break;
                case "80":
                    if(this.IsSmartMenu)
                    {
                        this.OnlineStreamingChannel = "Netflix";
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "81":
                    if (this.IsSmartMenu)
                    {
                        this.OnlineStreamingChannel = "Hulu";
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "82":
                    if (this.IsSmartMenu)
                    {
                        this.OnlineStreamingChannel = "Prime Video";
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "83":
                    if (this.IsSmartMenu)
                    {
                        this.OnlineStreamingChannel = "YouTube";
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "84":
                    if (this.IsSmartMenu)
                    {
                        IsSmartMenu = false;
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    this.IsError = true;
                    break;
            }

        }
    }
}

