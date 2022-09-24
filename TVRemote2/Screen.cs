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
        //public String Model
        //{
        //    get => this.Model;
        //    set { this.Model = value; }
        //}

        private bool power = false;
        private int currentVolume = 50; // 0 to 100
        private int currentChannel = 0;
        private bool mute = false;
        private int brightness = 50;
        private int contras = 50;
        private string onlineStreamingChannel = null; // Netflix, Hulu, etc

        public bool isSetting = false;
        public bool isSmartMenu = false;

        private bool isError = false;
        public bool IsError
        {
            get => this.isError;
            set => this.isError = value;
        }



        /*
         * setters
         */
        public void changePower()
        {
            this.power = !this.power;
        }

        public string getModel()
        {
            return this.model;
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
                case "7":
                    this.isSetting = true;
                    break;
                case "70":
                    if (this.isSetting)
                    {
                        this.changeBrightness();
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "71":
                    if (this.isSetting)
                    {
                        this.changeBrightness(false);
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "72":
                    if (this.isSetting)
                    {
                        this.changeContras();
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "73":
                    if (this.isSetting)
                    {
                        this.changeContras(false);
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "74":
                    if (this.isSetting)
                    {
                        this.isSetting = false;
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "8":
                    isSmartMenu = true;
                    break;
                case "80":
                    if(this.isSmartMenu)
                    {
                        this.setOnlineStreamingChannel("Netflix");
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "81":
                    if (this.isSmartMenu)
                    {
                        this.setOnlineStreamingChannel("Hulu");
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "82":
                    if (this.isSmartMenu)
                    {
                        this.setOnlineStreamingChannel("Prime Video");
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "83":
                    if (this.isSmartMenu)
                    {
                        this.setOnlineStreamingChannel("YouTube");
                    }
                    else
                    {
                        goto default;
                    }
                    break;
                case "84":
                    if (this.isSmartMenu)
                    {
                        isSmartMenu = false;
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

