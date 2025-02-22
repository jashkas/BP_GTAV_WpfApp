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
        public BpCounter() { }
        public BpCounter(bool x2, bool vip)
        {
            this.X2 = x2;
            this.Vip = vip;
        }
        public int GetAmount()
        {
            CheckVip();
            CheckX2();
            return mine + construction + port + postman + gym + farm + fireFighter + lottery + movieStudio + movieTheater + zerosCasinoDone + treasure + shootingRange;
        }
        //[JsonProperty("x2")]
        public bool X2 { get; set; } = false;

        //[JsonProperty("vip")]
        public bool Vip { get; set; } = true;

        //[JsonProperty("somewhereCounter")]
        public byte Somewhere { get; set; } = 0;

        //[JsonProperty("mineCounter")]
        private byte mine = 0;
        public byte Mine 
        { 
            get { return mine; }
            set { if (value >= 25) mine = 2; else mine = 0; }
        }

        //[JsonProperty("constructionCounter")]
        private byte construction = 0;
        public byte Construction 
        { 
            get { return construction; } 
            set{ if (value >= 25) construction = 2; else construction = 0; } 
        }

        //[JsonProperty("portCounter")]
        private byte port = 0;
        public byte Port 
        {
            get { return port; } 
            set { if (value >= 25) port = 2; else port = 0; }
        }

        //[JsonProperty("postmanCounter")]
        private byte postman = 0;
        public byte Postman
        {
            get { return postman; } 
            set  { if (value >= 10) postman = 1; else postman = 0; }
        }

        //[JsonProperty("gymCounter")]
        private byte gym = 0;
        public byte Gym 
        {
            get { return gym; }
            set { if (value >= 20) gym = 1; else gym = 0; }
        }

        //[JsonProperty("farmCounter")]
        private byte farm = 0;
        public byte Farm 
        {
            get { return farm; } 
            set { if (value >= 10) farm = 1; else farm = 0; }
        }

        //[JsonProperty("fireFighterCounter")]
        private byte fireFighter = 0;
        public byte FireFighter 
        {
            get { return fireFighter; } 
            set { if (value >= 10) fireFighter = 2; else fireFighter = 0; }
        }

        //[JsonProperty("lotteryCounter")]
        private byte lottery = 0;
        public byte Lottery 
        { 
            get { return lottery; } 
            set { if (value >= 1)  lottery = 1; else lottery = 0; }
        }

        //[JsonProperty("movieStudioCounter")]
        private byte movieStudio = 0;
        public bool MovieStudio
        {
            get
            {
                // Логика получения: если значение 2 - true, иначе - false
                return movieStudio == 2;
            }
            set
            {
                // Логика записи: если значение true - установить 2, иначе - 0
                movieStudio = (byte)(value ? 2 : 0);
            }
        }

        //[JsonProperty("movieTheaterCounter")]
        private byte movieTheater = 0;
        public bool MovieTheater
        {
            get
            {
                // Логика получения: если значение 1 - true, иначе - false
                return movieTheater >= 1;
            }
            set
            {
                // Логика записи: если значение true - установить 1, иначе - 0
                movieTheater = (byte)(value ? 1 : 0);
            }
        }

        //[JsonProperty("zerosCasinoDoneCounter")]
        private byte zerosCasinoDone = 0;
        public bool ZerosCasinoDone
    {
            get
            {
                // Логика получения: если значение 2 - true, иначе - false
                return zerosCasinoDone == 2;
            }
            set
            {
                // Логика записи: если значение true - установить 2, иначе - 0
                zerosCasinoDone = (byte)(value ? 2 : 0);
            }
        }

        //[JsonProperty("treasureCounter")]
        private byte treasure = 0;
        public byte Treasure
        {
            get { return treasure; }
            set { if (value >= 1) treasure = 1; else treasure = 0; }
        }

        //[JsonProperty("shootingRangeCounter")]
        private byte shootingRange = 0;
        public byte ShootingRange
        {
            get { return shootingRange; }
            set { if (value >= 1) shootingRange = 1; else shootingRange = 0; }
        }

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
                    movieStudio = 2;
                }
                if (bpDoing.MovieTheater == true)
                {
                    movieTheater = 1;
                }
                if (bpDoing.ZerosCasinoDone == true)
                {
                    zerosCasinoDone = 2;
                }
                if (bpDoing.TreasureDone >= 1)
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
                postman *= 2;
                gym *= 2;
                farm *= 2;
                fireFighter *= 2;
                lottery *= 2;
                movieStudio *= 2;
                movieTheater *= 2;
                zerosCasinoDone *= 2;
                treasure *= 2;
                shootingRange *= 2;
            }
        }

        private void CheckX2()
        {
            if (X2)
            {
                postman *= 2;
                gym *= 2;
                farm *= 2;
                fireFighter *= 2;
                lottery *= 2;
                movieStudio *= 2;
                movieTheater *= 2;
                zerosCasinoDone *= 2;
                treasure *= 2;
                shootingRange *= 2;
            }
        }
    }
}
