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
        private bool power = true;
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


    }
}

