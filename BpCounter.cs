using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_GTAV_WpfApp
{
    // BpCounter подсчитывает бипишки
    internal class BpCounter
    {
        public BpCounter(bool x2, bool vip)
        {
            this.X2 = x2;
            this.Vip = vip;
        }

        [JsonProperty("x2")]
        public bool X2 { get; set; } = false;

        [JsonProperty("vip")]
        public bool Vip { get; set; } = true;

        [JsonProperty("mineCounter")]
        public byte Mine { get; set; } = 0;

        [JsonProperty("constructionCounter")]
        public byte Construction { get; set; } = 0;

        [JsonProperty("portCounter")]
        public byte Port { get; set; } = 0;

        [JsonProperty("postmanCounter")]
        public byte Postman { get; set; } = 0;

        [JsonProperty("gymCounter")]
        public byte Gym { get; set; } = 0;

        [JsonProperty("farmCounter")]
        public byte Farm { get; set; } = 0;

        [JsonProperty("fireFighterCounter")]
        public byte FireFighter { get; set; } = 0;

        [JsonProperty("lotteryCounter")]
        public byte Lottery { get; set; } = 0;

        [JsonProperty("movieStudioCounter")]
        public byte MovieStudio { get; set; } = 0;

        [JsonProperty("movieTheaterCounter")]
        public byte MovieTheater { get; set; } = 0;

        [JsonProperty("zerosCasinoDoneCounter")]
        public byte ZerosCasinoDone { get; set; } = 0;

        [JsonProperty("treasureCounter")]
        public byte Treasure { get; set; } = 0;

        [JsonProperty("shootingRangeCounter")]
        public byte ShootingRange { get; set; } = 0;

        public void SetBpByDoing(BpDoing bpDoing)
        {
            if (bpDoing != null)
            {
                if (bpDoing.Mine >= 25)
                {
                    Mine = 2;
                }
                if (bpDoing.Construction >= 25)
                {
                    Construction = 2;
                }
                if (bpDoing.Port >= 25)
                {
                    Port = 2;
                }
                if (bpDoing.Postman >= 10)
                {
                    Postman = 1;
                }
                if (bpDoing.Gym >= 20)
                {
                    Gym = 1;
                }
                if (bpDoing.Farm >= 10)
                {
                    Farm = 1;
                }
                if (bpDoing.FireFighter >= 10)
                {
                    FireFighter = 2;
                }
                if (bpDoing.Lottery >= 1)
                {
                    Lottery = 1;
                }
                if (bpDoing.MovieStudio == true)
                {
                    MovieStudio = 2;
                }
                if (bpDoing.MovieTheater == true)
                {
                    MovieTheater = 1;
                }
                if (bpDoing.ZerosCasinoDone == true)
                {
                    ZerosCasinoDone = 2;
                }
                if (bpDoing.Treasure >= 1)
                {
                    Treasure = 1;
                } 
                if (bpDoing.ShootingRange >= 1)
                {
                    ShootingRange = 1;
                }
                CheckVip();
                CheckX2();
            }
        }

        private void CheckVip()
        {
            if (Vip)
            {
                Postman *= 2;
                Gym *= 2;
                Farm *= 2;
                FireFighter *= 2;
                Lottery *= 2;
                MovieStudio *= 2;
                MovieTheater *= 2;
                ZerosCasinoDone *= 2;
                Treasure *= 2;
                ShootingRange *= 2;
            }
        }

        private void CheckX2()
        {
            if (X2)
            {
                Postman *= 2;
                Gym *= 2;
                Farm *= 2;
                FireFighter *= 2;
                Lottery *= 2;
                MovieStudio *= 2;
                MovieTheater *= 2;
                ZerosCasinoDone *= 2;
                Treasure *= 2;
                ShootingRange *= 2;
            }
        }
    }
}
