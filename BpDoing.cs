using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Newtonsoft.Json;

namespace BP_GTAV_WpfApp
{
    // Данный класс подсчитывает действия
    internal class BpDoing
    {
        public BpDoing() { }

        [JsonProperty("mineDoing")]
        public int Mine { get; set; } = 0;

        [JsonProperty("constructionDoing")]
        public int Construction { get; set; } = 0;

        [JsonProperty("portDoing")]
        public int Port { get; set; } = 0;

        [JsonProperty("postmanDoing")]
        public int Postman { get; set; } = 0;

        [JsonProperty("gymDoing")]
        public int Gym { get; set; } = 0;

        [JsonProperty("farmDoing")]
        public int Farm { get; set; } = 0;

        [JsonProperty("fireFighterDoing")]
        public int FireFighter { get; set; } = 0;

        [JsonProperty("lotteryDoing")]
        public int Lottery { get; set; } = 0;

        [JsonProperty("movieStudioDoing")]
        public bool MovieStudio { get; set; } = false;

        [JsonProperty("movieTheaterDoing")]
        public bool MovieTheater { get; set; } = false;

        [JsonProperty("zerosCasinoDoneDoing")]
        public bool ZerosCasinoDone { get; set; } = false;

        [JsonProperty("zerosCasinoAttemptDoing")]
        public int ZerosCasinoAttempt { get; set; } = 0;

        [JsonProperty("treasureDoing")]
        public int Treasure { get; set; } = 0;

        [JsonProperty("shootingRangeDoing")]
        public int ShootingRange { get; set; } = 0;
    }
}
