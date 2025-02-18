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
        public byte Mine { get; set; } = 0;

        [JsonProperty("constructionDoing")]
        public byte Construction { get; set; } = 0;

        [JsonProperty("portDoing")]
        public byte Port { get; set; } = 0;

        [JsonProperty("postmanDoing")]
        public byte Postman { get; set; } = 0;

        [JsonProperty("gymDoing")]
        public byte Gym { get; set; } = 0;

        [JsonProperty("farmDoing")]
        public byte Farm { get; set; } = 0;

        [JsonProperty("fireFighterDoing")]
        public byte FireFighter { get; set; } = 0;

        [JsonProperty("lotteryDoing")]
        public byte Lottery { get; set; } = 0;

        [JsonProperty("movieStudioDoing")]
        public bool MovieStudio { get; set; } = false;

        [JsonProperty("movieTheaterDoing")]
        public bool MovieTheater { get; set; } = false;

        [JsonProperty("zerosCasinoDoneDoing")]
        public bool ZerosCasinoDone { get; set; } = false;

        [JsonProperty("zerosCasinoAttemptDoing")]
        public byte ZerosCasinoAttempt { get; set; } = 0;

        [JsonProperty("treasureDoneDoing")]
        public byte TreasureDone { get; set; } = 0;
        [JsonProperty("treasureDoing")]
        public byte TreasureAttempt { get; set; } = 0;

        [JsonProperty("shootingRangeDoing")]
        public byte ShootingRange { get; set; } = 0;
    }
}
